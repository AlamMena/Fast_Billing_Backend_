using API.DbModels.AccountsReceivable;
using API.DbModels.Contexts;
using API.DbModels.Inventory.Products;
using API.DbModels.Invoices;
using API.Dtos.Sales.Invoices;
using API.Enums;
using API.Extensions;
using API.Services.Sales.Ncf;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.Services.Sales.Invoices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly FbContext _context;
        private readonly INcfService _ncfService;
        public InvoiceService(FbContext context, INcfService ncfService)
        {
            _context = context;
            _ncfService = ncfService;
        }

        private async Task<bool> SetInvoiceClientAsync(Invoice invoice)
        {
            // client information
            var client = await _context.Clients.Include(d => d.Addresses).FirstAsync(d => d.Id == invoice.ClientId)
                ?? throw new ValidationException("Client is not valid");

            // client information
            invoice.Client = client;
            invoice.ClientName = client.Name;
            invoice.ClientEmail = client.Email;
            invoice.ClientNoIdentification = client.NoIdentification;
            invoice.ClientAddress = client.Addresses.FirstOrDefault(d => d.Main)?.Address;

            return true;
        }
        public async Task<bool> SetInvoiceTypeAsync(Invoice invoice)
        {
            // validating type
            var type = await _context.InvoiceTypes.FindAsync(invoice.TypeId);
            if (type is null)
            {
                throw new ValidationException("The invoice type is not valid");
            }

            // setting name
            invoice.InvoiceTypeName = type.Name;

            // validating that client has a type that allow credit invoice
            if (invoice.TypeId == (int)InvoiceTypes.Credit)
            {
                if (invoice.Client.TypeId == (int)ClientTypes.Cash)
                {
                    throw new ValidationException("The client dosen't have allowed this invoice type");
                }
            }

            return true;
        }

        private async Task<bool> ValidateInvoiceProductsAsync(IEnumerable<InvoiceDetail> details)
        {
            // validating products repeated
            var productsAreRepeated = details.GroupBy(d => d.ProductId).Any(d => d.Count() > 1);
            if (productsAreRepeated)
            {
                throw new ValidationException("Details repeated");
            }

            // selecting only the field 'productid' from invoice details request
            var invoiceRequestProductsIds = details.Select(d => d.ProductId);

            // looking for products that are inside the invoice request in the database
            var products = await _context.Products
                .Where(d => invoiceRequestProductsIds.Contains(d.Id)).Select(d => d.Id).ToListAsync();

            // if the invoice doesn't contains any product that exists in the database an exception is thrown
            if (!products.Any())
            {
                throw new ValidationException("Products are not valid");
            }

            // if the invoice request contains products that dosen't exists an exception is thrown
            var allProductsExists = !invoiceRequestProductsIds.Except(products).Any();
            if (!allProductsExists)
            {
                throw new ValidationException("Products are not valid");
            }

            return true;
        }
        private async Task<Invoice> CalculateInvoiceAsync(Invoice invoice)
        {
            // validating products
            await ValidateInvoiceProductsAsync(invoice.Details);

            // looking for products
            var products = await _context.Products
                .Include(d => d.Prices)
                .Include(d => d.Stocks)
                .Where(d => invoice.Details.Select(d => d.ProductId).Contains(d.Id))
                .ToListAsync();

            // calculating every detail
            foreach (var detail in invoice.Details)
            {
                var product = products.First(d => d.Id == detail.ProductId);

                // setting product name to invoice
                detail.ProductName = product.Name;

                // adding the product transaction by detail to track the out/in products
                detail.ProductTransactions.Add(new ProductTransaction
                {
                    WarehouseId = product.Stocks.First().WarehouseId,
                    ProductCost = product.Prices.First().Cost,
                    ProductPrice = product.Prices.First().Price,
                    ProductId = product.Id,
                    Quantity = detail.Quantity,
                    Sign = TransactionType.Outcome,
                    OldQuantity = 0,
                    NewQuantity = product.Stocks.First().Stock - detail.Quantity,
                    NewCost = product.Prices.First().Cost,
                    Note = "N/A",
                    Document = AccountDocuments.Invoice.GetDocumentKey(),
                    ExpirationDate = null,
                    CompanyId = _context.tenant.CompanyId,
                    BranchId = _context.tenant.BranchId,
                });

                // calculating details
                detail.Cost = product.Prices.First().Cost;
                detail.Price = product.Prices.First().Price;
                detail.Tax = product.Tax;
                detail.TaxAmount = detail.Price * detail.Tax > 0 ? (detail.Tax / 100) : 1;
                detail.Discount = 0;
                detail.DiscountAmount = 0;
                detail.Excent = false;
                detail.Total = (detail.Price * detail.Quantity) * (detail.Tax > 0 ? (detail.Tax / 100) : 1);
            }

            // calculating header
            invoice.Subtotal = invoice.Details.Sum(d => d.Price);
            invoice.Tax = invoice.Details.Sum(d => d.Tax / 100);
            invoice.TaxAmount = invoice.Details.Sum(d => d.TaxAmount);
            invoice.Discount = 0;
            invoice.TotalPayed = invoice.Payments.Sum(d => d.Amount);
            invoice.Return = invoice.TotalPayed - invoice.Total;
            invoice.Total = invoice.Details.Sum(d => d.Total);

            // validating payment
            if (invoice.TotalPayed < invoice.Total)
            {
                throw new ValidationException("Total payed is not valid");
            }

            return invoice;
        }

        public void BuildAccountReceivableFromInvoice(Invoice invoice)
        {
            invoice.AccountReceivable = new AccountReceivable
            {
                ClientId = invoice.ClientId,
                ClientName = invoice.Client.Name,
                ClientDocNum = invoice.Client.DocNum,
                InitialDate = invoice.Date,
                ExpirationDate = invoice.NcfExpiration,
                TaxAmount = invoice.TaxAmount,
                Amount = invoice.Total,
                Balance = 0,
                Document = AccountDocuments.Invoice.GetDocumentKey(),
                Reference = invoice.DocNum,
                Confirmed = true,
            };

            invoice.AccountReceivable.Transactions.Add(new AccountReceivableTransaction()
            {
                Amount = invoice.Total,
                Sign = TransactionType.Outcome,
                Document = AccountDocuments.Invoice.GetDocumentKey(),
            });

        }
        private void BuildPaymentFromInvoice(Invoice invoice)
        {
            // generating payments
            invoice.Payments.ToList().ForEach(d =>
            {
                d.Id = 0;
                d.CompanyId = _context.tenant.CompanyId;
                d.BranchId = _context.tenant.BranchId;
                d.Amount = invoice.Total;
                d.Document = AccountDocuments.Invoice.GetDocumentKey();
                d.Reference = invoice.DocNum;
            });

            // pay transaction 
            invoice.AccountReceivable.Transactions.Add(new AccountReceivableTransaction()
            {
                Amount = invoice.Total,
                Sign = TransactionType.Income,
                Document = AccountDocuments.Invoice.GetDocumentKey(),
            });
        }

        private async Task<bool> SetInvoiceNcfAsync(Invoice invoice)
        {
            var ncfType = await _context.NcfTypes.FirstOrDefaultAsync(d => d.Id == invoice.NcfTypeId);
            if (ncfType is null)
            {
                throw new ValidationException("The ncf type is not valid");
            }

            invoice.NcfName = ncfType.Name;

            var ncfResponse = await _ncfService.GenerateNcfAsync(invoice.NcfTypeId);
            invoice.Ncf = ncfResponse.Ncf;

            return true;
        }
        private async Task<bool> UpdateProductStock(Invoice invoice)
        {
            await _context.Products
                 .Include(d => d.Transactions)
                 .Include(d => d.Stocks)
                 .Where(d => invoice.Details.Select(d => d.ProductId).Contains(d.Id))
                 .ForEachAsync(product =>
                 {
                     var productStock = product.Stocks.First(d => d.WarehouseId == invoice.WareHouseId);
                     productStock.Stock = product.Transactions.Sum(d => d.Quantity * (int)d.Sign);

                 });
            return true;
        }

        public async Task<Invoice> PostInvoiceAsync(Invoice invoice)
        {
            await _context.Database.BeginTransactionAsync();

            await SetInvoiceClientAsync(invoice);

            await SetInvoiceTypeAsync(invoice);

            await CalculateInvoiceAsync(invoice);

            await UpdateProductStock(invoice);

            BuildAccountReceivableFromInvoice(invoice);

            BuildPaymentFromInvoice(invoice);

            await SetInvoiceNcfAsync(invoice);

            await _context.AddAsync(invoice);
            await _context.SaveChangesAsync();

            await _context.Database.CommitTransactionAsync();

            return invoice;
        }
    }
}
