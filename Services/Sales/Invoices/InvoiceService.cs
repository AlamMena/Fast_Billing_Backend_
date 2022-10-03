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
        private readonly IMapper _mapper;
        private readonly INcfService _ncfService;
        public InvoiceService(FbContext context, IMapper mapper, INcfService ncfService)
        {
            _context = context;
            _mapper = mapper;
            _ncfService = ncfService;
        }

        private async Task<bool> ValidateInvoiceAsync(Invoice invoice)
        {
            // validation invoice type
            var invoiceTypeExists = await _context.InvoiceTypes.AnyAsync(d => d.Id == invoice.InvoiceTypeId);
            if (!invoiceTypeExists)
            {
                throw new ValidationException("The invoice type is not valid");
            }

            // validation ncf type
            var ncfTypeExists = await _context.NcfTypes.AnyAsync(d => d.Id == invoice.NcfTypeId);
            if (!invoiceTypeExists)
            {
                throw new ValidationException("The ncf type is not valid");
            }

            // validating invoice client
            var clientExists = await _context.Clients.FindAsync(invoice.ClientId);
            if (clientExists is null)
            {
                throw new ValidationException("The client is not valid");
            }

            // validate products 
            await ValidateInvoiceProductsAsync(invoice.Details);

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
        private async Task<bool> SetInvoiceNcf(Invoice invoice)
        {
            // ncf configuration
            var ncfResponse = await _ncfService.GetNcfAsync(invoice.NcfTypeId);
            invoice.Ncf = ncfResponse.Ncf;
            // invoice.NcfExpiration = ncfResponse.ExpirationDate;

            // invoice ncf type name 
            invoice.NcfName = await _context.NcfTypes
                .Where(d => d.Id == invoice.NcfTypeId).Select(d => d.Name).FirstAsync();

            return true;
        }
        private async Task<bool> SetProductDataToInvoiceDetailsAsync(IEnumerable<InvoiceDetail> details)
        {
            var productsIds = details.Select(d => d.ProductId);
            var products = await _context.Products.Where(d => productsIds.Contains(d.Id)).ToListAsync();

            // setting product name to the list
            details.ToList()
                .ForEach(d => d.ProductName = products.First(p => p.Id == d.ProductId).Name);

            return true;
        }
        private async Task<bool> SetClientDataAsync(Invoice invoice)
        {
            // client information
            var client = await _context.Clients.FindAsync(invoice.ClientId)
                ?? throw new ValidationException("Client is not valid");

            // client information
            invoice.ClientName = client.Name;
            invoice.ClientEmail = client.Email;
            invoice.ClientNoIdentification = client.NoIdentification;
            invoice.ClientAddress = client.Addresses.FirstOrDefault(d => d.Main)?.Address;

            return true;
        }
        private async Task<bool> PayInvoiceAsync(Invoice invoice)
        {
            var client = await _context.Clients.FindAsync(invoice.ClientId);
            if (client is null)
            {
                throw new ValidationException("The client is not valid");
            }

            // initial account
            var account = new AccountReceivable
            {
                ClientId = invoice.ClientId,
                ClientName = client.Name,
                ClientDocNum = client.DocNum,
                InitialDate = invoice.Date,
                ExpirationDate = invoice.NcfExpiration,
                TaxAmount = invoice.TaxAmount,
                Amount = invoice.Total,
                Balance = 0,
                Document = AccountDocuments.Invoice.GetDocumentKey(),
                Reference = invoice.DocNum,
                Confirmed = true,
            };

            //  out transaction
            account.Transactions.Add(new AccountReceivableTransaction()
            {
                Amount = invoice.Total,
                Sign = TransactionType.Outcome,
                Document = AccountDocuments.Invoice.GetDocumentKey(),
                Reference = account.DocNum
            });


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

            // in transaction 
            account.Transactions.Add(new AccountReceivableTransaction()
            {
                Amount = invoice.Total,
                Sign = TransactionType.Income,
                Document = AccountDocuments.Invoice.GetDocumentKey(),
                Reference = account.DocNum
            });

            // adding account to invoice
            invoice.AccountReceivables.Add(account);

            await _context.SaveChangesAsync();

            return true;

        }
        private async Task<Invoice> CalculateInvoiceAsync(Invoice invoice)
        {
            var products = await _context.Products
                .Include(d => d.Prices)
                .Include(d=>d.Stocks)
                .Where(d => invoice.Details.Select(d => d.ProductId).Contains(d.Id))
                .ToListAsync();

            foreach (var detail in invoice.Details)
            {
                var product = products.First(d => d.Id == detail.ProductId);
                product.Transactions.Add(new ProductTransaction
                {
                    WarehouseId = product.Stocks.First().WarehouseId,
                    ProductCost = product.Prices.First().Cost,
                    ProductPrice = product.Prices.First().Price,
                    Quantity = detail.Quantity,
                    Sign = TransactionType.Outcome,
                    OldQuantity = 0,
                    NewQuantity = product.Stocks.First().Stock - detail.Quantity,
                    NewCost = product.Prices.First().Cost,
                    Note = "Initial transaction",
                    Document = "IT",
                    ExpirationDate = null,
                    CompanyId = _context.tenant.CompanyId,
                    BranchId = _context.tenant.BranchId,
                });

                detail.Cost = product.Prices.First().Cost;
                detail.Price = product.Prices.First().Price;
                detail.Tax = product.Tax;
                detail.TaxAmount = detail.Price * detail.Tax > 0 ? (detail.Tax / 100) : 1;
                detail.Discount = 0;
                detail.DiscountAmount = 0;
                detail.Excent = false;
                detail.Total = (detail.Price * detail.Quantity) * detail.Tax > 0 ? (detail.Tax / 100) : 1;
            }

            invoice.Subtotal = invoice.Details.Sum(d => d.Price);
            invoice.Tax = invoice.Details.Sum(d => d.Tax / 100);
            invoice.TaxAmount = invoice.Details.Sum(d => d.TaxAmount);
            invoice.Discount = 0;
            invoice.TotalPayed = invoice.Payments.Sum(d => d.Amount);
            invoice.Total = invoice.Details.Sum(d => d.Total);

            if (invoice.TotalPayed < invoice.Total)
            {
                throw new ValidationException("Total payed is not valid");
            }

            return invoice;
        }
        public async Task<Invoice> PostInvoiceAsync(Invoice invoice)
        {
            await _context.Database.BeginTransactionAsync();


            // validating the request
            await ValidateInvoiceAsync(invoice);

            // configuring ncf
            await SetInvoiceNcf(invoice);

            // getting invoice type name
            invoice.InvoiceTypeName = await _context.InvoiceTypes
                .Where(d => d.Id == invoice.NcfTypeId).Select(d => d.Name).FirstAsync();

            // setting product data
            await SetProductDataToInvoiceDetailsAsync(invoice.Details);

            // setting client data
            await SetClientDataAsync(invoice);

            // calculating 
            await CalculateInvoiceAsync(invoice);

            // account receivable
            await PayInvoiceAsync(invoice);

            await _context.AddAsync(invoice);
            await _context.SaveChangesAsync();

            // commiting changes
            await _context.Database.CommitTransactionAsync();

            return invoice;
        }
    }
}
