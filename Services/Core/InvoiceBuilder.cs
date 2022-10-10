//using API.DbModels.AccountsReceivable;
//using API.DbModels.Contexts;
//using API.DbModels.Inventory.Products;
//using API.DbModels.Invoices;
//using API.DbModels.Products;
//using API.Enums;
//using API.Extensions;
//using API.Services.Sales.Ncf;
//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;

//namespace API.Services.Core
//{
//    public class InvoiceBuilder
//    {
//        private readonly FbContext _context;
//        private readonly INcfService _ncfService;
//        public InvoiceBuilder(FbContext context, INcfService ncfService)
//        {
//            _context = context;
//            _ncfService = ncfService;
//        }
//        private Invoice Invoice = new();
//        private async Task<Invoice> SetInvoiceClientAsync()
//        {
//            // client information
//            var client = await _context.Clients.Include(d => d.Addresses).FirstOrDefaultAsync(d => d.Id == Invoice.ClientId)
//                ?? throw new ValidationException("Client is not valid");

//            // client information
//            Invoice.Client = client;
//            Invoice.ClientName = client.Name;
//            Invoice.ClientEmail = client.Email;
//            Invoice.ClientNoIdentification = client.NoIdentification;
//            Invoice.ClientAddress = client.Addresses.FirstOrDefault(d => d.Main)?.Address1;

//            return Invoice;
//        }
//        public async Task<Invoice> SetInvoiceTypeAsync()
//        {
//            // validating type
//            var type = await _context.InvoiceTypes.FindAsync(Invoice.TypeId);
//            if (type is null)
//            {
//                throw new ValidationException("The invoice type is not valid");
//            }

//            // setting name
//            Invoice.InvoiceTypeName = type.Name;

//            // validating that client has a type that allow credit invoice
//            if (Invoice.TypeId == (int)InvoiceTypes.Credit)
//            {
//                if (Invoice.Client.TypeId == (int)ClientTypes.Cash)
//                {
//                    throw new ValidationException("The client dosen't have allowed this invoice type");
//                }
//            }

//            return Invoice;
//        }

//        private Invoice ValidateInvoiceProductsAsync(IEnumerable<InvoiceDetail> details, IEnumerable<Product> products)
//        {
//            // validating products repeated
//            var productsAreRepeated = details.GroupBy(d => d.ProductId).Any(d => d.Count() > 1);
//            if (productsAreRepeated)
//            {
//                throw new ValidationException("Details repeated");
//            }

//            // selecting only the field 'productid' from invoice details request
//            var invoiceRequestProductsIds = details.Select(d => d.ProductId);

//            // if the invoice doesn't contains any product that exists in the database an exception is thrown
//            if (!products.Any())
//            {
//                throw new ValidationException("Products are not valid");
//            }

//            // if the invoice request contains products that dosen't exists an exception is thrown
//            var allProductsExists = !invoiceRequestProductsIds.Except(products.Select(d => d.Id)).Any();
//            if (!allProductsExists)
//            {
//                throw new ValidationException("Products are not valid");
//            }

//            return Invoice;
//        }
//        private async Task<Invoice> CalculateInvoiceAsync()
//        {
//            // looking for products
//            var products = await _context.Products
//                .Include(d => d.Prices) // prices logic are defined in global querys
//                .Include(d => d.Stocks) // stocks logic are defined in global querys
//                .Where(d => Invoice.Details.Select(d => d.ProductId).Contains(d.Id))
//                .ToListAsync();

//            // validating products
//            ValidateInvoiceProductsAsync(Invoice.Details, products);

//            // calculating every detail
//            foreach (var detail in Invoice.Details)
//            {
//                var product = products.First(d => d.Id == detail.ProductId);

//                detail.ProductName = product.Name;

//                // calculating details
//                detail.Product = product;
//                detail.Cost = product.Prices.First().Cost;
//                detail.Price = product.Prices.First().Price;
//                detail.Tax = product.Tax;
//                detail.TaxAmount = detail.Price * detail.Tax > 0 ? (detail.Tax / 100) : 1;
//                detail.Discount = 0;
//                detail.DiscountAmount = 0;
//                detail.Excent = false;
//                detail.Total = (detail.Price * detail.Quantity) * (detail.Tax > 0 ? (detail.Tax / 100) : 1);
//            }

//            // calculating header
//            Invoice.Subtotal = Invoice.Details.Sum(d => d.Price);
//            Invoice.Tax = Invoice.Details.Sum(d => d.Tax / 100);
//            Invoice.TaxAmount = Invoice.Details.Sum(d => d.TaxAmount);
//            Invoice.Discount = 0;
//            Invoice.TotalPayed = Invoice.Payments.Sum(d => d.Amount);
//            Invoice.Return = Invoice.TotalPayed - Invoice.Total;
//            Invoice.Total = Invoice.Details.Sum(d => d.Total);

//            return Invoice;
//        }

//        public Invoice BuildAccountReceivableFromInvoice()
//        {
//            Invoice.AccountReceivable = new AccountReceivable
//            {
//                ClientId = Invoice.ClientId,
//                ClientName = Invoice.Client.Name,
//                ClientDocNum = Invoice.Client.DocNum,
//                InitialDate = Invoice.Date,
//                ExpirationDate = Invoice.NcfExpiration,
//                TaxAmount = Invoice.TaxAmount,
//                Amount = Invoice.Total,
//                Balance = Invoice.Total,
//                Document = AccountDocuments.Invoice.GetDocumentKey(),
//                Reference = Invoice.DocNum,
//                Confirmed = true,
//            };

//            Invoice.AccountReceivable.Transactions.Add(new AccountReceivableTransaction()
//            {
//                Amount = Invoice.Total,
//                Sign = TransactionType.Income,
//                Document = AccountDocuments.Invoice.GetDocumentKey(),
//            });

//            return Invoice;
//        }
//        private async Task<Invoice> BuildPaymentFromInvoice()
//        {
//            // validating payment
//            if (Invoice.TotalPayed < Invoice.Total && Invoice.TypeId == (int)InvoiceTypes.Cash)
//            {
//                throw new ValidationException("Total payed is not valid");
//            }

//            var paymentTypes = await _context.PaymentTypes.ToListAsync();

//            if (Invoice.TotalPayed > 0)
//            {
//                // generating payments
//                foreach (var payment in Invoice.Payments)
//                {
//                    if (paymentTypes.Any(d => d.Id == payment.TypeId) is not true)
//                    {
//                        throw new ValidationException("The payment type is not valid");
//                    }

//                    payment.Id = 0;
//                    payment.BankId = null;
//                    payment.CompanyId = _context.tenant.CompanyId;
//                    payment.BranchId = _context.tenant.BranchId;
//                    payment.Amount = Invoice.TotalPayed >= Invoice.Total ? Invoice.Total : payment.Amount;
//                    payment.Document = AccountDocuments.Invoice.GetDocumentKey();
//                    payment.Reference = Invoice.DocNum;
//                }

//                // pay transaction 
//                Invoice.AccountReceivable.Transactions.Add(new AccountReceivableTransaction()
//                {
//                    Amount = Invoice.TotalPayed >= Invoice.Total ? Invoice.Total : Invoice.TotalPayed,
//                    Sign = TransactionType.Outcome,
//                    Document = AccountDocuments.Invoice.GetDocumentKey(),
//                });
//            }

//            // update account balance
//            Invoice.AccountReceivable.Balance = Invoice.AccountReceivable.Transactions.Sum(d => (int)d.Sign * d.Amount);

//            return Invoice;
//        }

//        private async Task<Invoice> SetInvoiceNcfAsync()
//        {
//            var ncfType = await _context.NcfTypes.FirstOrDefaultAsync(d => d.Id == Invoice.NcfTypeId);
//            if (ncfType is null)
//            {
//                throw new ValidationException("The ncf type is not valid");
//            }

//            Invoice.NcfName = ncfType.Name;

//            var ncfResponse = await _ncfService.GenerateNcfAsync(Invoice.NcfTypeId);
//            Invoice.Ncf = ncfResponse.Ncf;

//            return Invoice;
//        }
//        public async Task<Invoice> UpdateStockAsync()
//        {
//            foreach (var detail in Invoice.Details)
//            {
//                await _context.AddAsync(new ProductTransaction
//                {
//                    WarehouseId = Invoice.WareHouseId,
//                    ProductCost = detail.Cost,
//                    ProductPrice = detail.Price,
//                    Quantity = detail.Quantity,
//                    ProductId = detail.ProductId,
//                    Sign = TransactionType.Outcome,
//                    OldQuantity = 0,
//                    NewQuantity = detail.Quantity,
//                    NewCost = detail.Cost,
//                    Note = "N/A",
//                    Document = AccountDocuments.Invoice.GetDocumentKey(),
//                    ExpirationDate = null,
//                    CompanyId = _context.tenant.CompanyId,
//                    BranchId = _context.tenant.BranchId,
//                });

//            }
//            // updating stock
//            await _context.Products
//                .Include(d => d.Stocks.Where(d => d.WarehouseId == Invoice.WareHouseId))
//                .Include(d => d.Transactions)
//                .Where(d => Invoice.Details.Select(d => d.ProductId).Contains(d.Id))
//                .ForEachAsync(d => d.Stocks.First().Stock = d.Transactions.Sum(d => (int)d.Sign * d.Quantity));

//            return Invoice;
//        }
//        public async Task<Invoice> PostInvoiceAsync(Invoice invoice)
//        {
//            await _context.Database.BeginTransactionAsync();

//            await SetInvoiceClientAsync();

//            await SetInvoiceTypeAsync();

//            await CalculateInvoiceAsync();

//            BuildAccountReceivableFromInvoice();

//            await BuildPaymentFromInvoice();

//            await SetInvoiceNcfAsync();

//            await UpdateStockAsync();

//            //await _context.AddAsync();
//            //await _context.SaveChangesAsync();

//            await _context.Database.CommitTransactionAsync();

//            return invoice;
//        }
//    }
//}

