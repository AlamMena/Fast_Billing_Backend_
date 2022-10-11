using API.DbModels.Accounts.AccountsPayable;
using API.DbModels.Contexts;
using API.DbModels.Inventory.GoodsReceipt;
using API.DbModels.Inventory.Products;
using API.DbModels.Products;
using API.Enums;
using API.Extensions;
using API.Services.Sales.Ncf;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.Services.Inventory
{
    public class GoodReceiptService : IGoodReceiptService
    {
        private readonly FbContext _context;
        private readonly INcfService _ncfService;
        public GoodReceiptService(FbContext context, INcfService ncfService)
        {
            _context = context;
            _ncfService = ncfService;
        }
        public async Task<bool> SetSupplierAsync(GoodReceipt receipt)
        {
            var supplier = await _context.Suppliers
                .Include(d => d.Addresses.Where(d => d.Main))
                .Include(d => d.Contacts.Where(d => d.Main))
                .FirstOrDefaultAsync(d => d.Id == receipt.SupplierId);

            if (supplier is null)
            {
                throw new ValidationException("The supplier is not valid");
            }

            receipt.SupplierName = supplier.Name;
            receipt.SupplierAddress = supplier.Addresses.First().Address1;
            receipt.SupplierPhone = supplier.Contacts.First().Number;
            receipt.SupplierNoIdentification = supplier.NoIdentification;
            receipt.SupplierEmail = supplier.Email;

            return true;
        }

        private static void ValidateInvoiceProductsAsync(IEnumerable<GoodReceiptDetail> details, IEnumerable<Product> products)
        {
            // validating products repeated
            var productsAreRepeated = details.GroupBy(d => d.ProductId).Any(d => d.Count() > 1);
            if (productsAreRepeated)
            {
                throw new ValidationException("Details repeated");
            }

            // selecting only the field 'productid' from invoice details request
            var invoiceRequestProductsIds = details.Select(d => d.ProductId);

            // if the invoice doesn't contains any product that exists in the database an exception is thrown
            if (!products.Any())
            {
                throw new ValidationException("Products are not valid");
            }

            // if the invoice request contains products that dosen't exists an exception is thrown
            var allProductsExists = !invoiceRequestProductsIds.Except(products.Select(d => d.Id)).Any();
            if (!allProductsExists)
            {
                throw new ValidationException("Products are not valid");
            }
        }

        public async Task<bool> CalculateReceiptAsync(GoodReceipt receipt)
        {
            // looking for products
            var products = await _context.Products
                .Include(d => d.Prices) // prices logic are defined in global querys
                .Include(d => d.Stocks) // stocks logic are defined in global querys
                .Where(d => receipt.Details.Select(d => d.ProductId).Contains(d.Id))
                .ToListAsync();

            // validating products
            ValidateInvoiceProductsAsync(receipt.Details, products);

            // calculating every detail
            foreach (var detail in receipt.Details)
            {
                var product = products.First(d => d.Id == detail.ProductId);

                detail.ProductName = product.Name;

                // calculating details
                detail.Product = product;
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
            receipt.Subtotal = receipt.Details.Sum(d => d.Price);
            receipt.Tax = receipt.Details.Sum(d => d.Tax / 100);
            receipt.TaxAmount = receipt.Details.Sum(d => d.TaxAmount);
            receipt.Discount = 0;
            receipt.TotalPayed = receipt.Payments.Sum(d => d.Amount);
            receipt.Return = receipt.TotalPayed - receipt.Total;
            receipt.Total = receipt.Details.Sum(d => d.Total);

            return true;
        }
        public void BuildAccountPayableFromReceipt(GoodReceipt receipt)
        {
            receipt.Account = new AccountPayable
            {
                Ncf = receipt.Ncf,
                Date = receipt.Date,
                ExpirationDate = receipt.Date.AddDays(receipt.Days),
                SupplierName = receipt.Supplier.Name,
                SupplierReceipt = receipt.InvoiceNumber,
                SupplierNoIdentification = receipt.SupplierNoIdentification,
                SupplierDocNum = receipt.Supplier.DocNum,
                Description = "N/A",
                Balance = receipt.Total,
                Document = AccountDocuments.GoodReceipt.GetDocumentKey(),
                Reference = receipt.DocNum,
                Confirmed = true,
            };

            receipt.Account.Transactions.Add(new AccountPaybleTransaction()
            {
                Amount = receipt.Total,
                Sign = TransactionType.Income,
                Document = AccountDocuments.Invoice.GetDocumentKey(),
            });

        }
        private async Task<bool> SetReceiptNcfAsync(GoodReceipt receipt)
        {
            var ncfType = await _context.NcfTypes.FirstOrDefaultAsync(d => d.Id == receipt.NcfTypeId);
            if (ncfType is null)
            {
                throw new ValidationException("The ncf type is not valid");
            }

            receipt.NcfName = ncfType.Name;

            var ncfResponse = await _ncfService.GenerateNcfAsync(receipt.NcfTypeId);
            receipt.Ncf = ncfResponse.Ncf;

            return true;
        }
        private async Task<GoodReceipt> BuildPaymentFromInvoice(GoodReceipt receipt)
        {
            var paymentTypes = await _context.PaymentTypes.ToListAsync();

            if (receipt.TotalPayed > 0)
            {
                // generating payments
                foreach (var payment in receipt.Payments)
                {
                    if (paymentTypes.Any(d => d.Id == payment.TypeId) is not true)
                    {
                        throw new ValidationException("The payment type is not valid");
                    }

                    payment.Id = 0;
                    payment.BankId = null;
                    payment.CompanyId = _context.tenant.CompanyId;
                    payment.BranchId = _context.tenant.BranchId;
                    payment.Amount = receipt.TotalPayed >= receipt.Total ? receipt.Total : payment.Amount;
                    payment.Document = AccountDocuments.Invoice.GetDocumentKey();
                    payment.Reference = receipt.DocNum;
                }

                // pay transaction 
                receipt.Account.Transactions.Add(new AccountPaybleTransaction()
                {
                    Amount = receipt.TotalPayed >= receipt.Total ? receipt.Total : receipt.TotalPayed,
                    Sign = TransactionType.Outcome,
                    Document = AccountDocuments.Invoice.GetDocumentKey(),
                });
            }

            // update account balance
            receipt.Account.Balance = receipt.Account.Transactions.Sum(d => (int)d.Sign * d.Amount);

            return receipt;
        }

        public async Task<bool> UpdateStockAsync(GoodReceipt receipt)
        {
            var products = await _context.Products
                .Include(d => d.Stocks)
                .ThenInclude(d => d.Transactions)
                .Where(d => receipt.Details.Select(d => d.ProductId).Contains(d.Id))
                .ToListAsync();

            foreach (var detail in receipt.Details)
            {
                var product = products.First(d => d.Id == detail.ProductId);

                if (product.Stocks.FirstOrDefault(d => d.WarehouseId == detail.WarehouseId) is null)
                {
                    product.Stocks.Add(new ProductStock
                    {
                        Stock = detail.Quantity,
                        WarehouseId = detail.WarehouseId,
                    });
                }

                await _context.AddAsync(new ProductTransaction
                {
                    WarehouseId = detail.WarehouseId,
                    ProductCost = detail.Cost,
                    ProductPrice = detail.Price,
                    Quantity = detail.Quantity,
                    ProductId = detail.ProductId,
                    Sign = TransactionType.Outcome,
                    OldQuantity = 0,
                    NewQuantity = detail.Quantity,
                    NewCost = detail.Cost,
                    Note = "N/A",
                    Document = AccountDocuments.Invoice.GetDocumentKey(),
                    ExpirationDate = null,
                    CompanyId = _context.tenant.CompanyId,
                    BranchId = _context.tenant.BranchId,
                });

                var productStock = product.Stocks.First(d => d.WarehouseId == detail.WarehouseId);
                productStock.Stock = productStock.Transactions.Sum(d => (int)d.Sign * d.Quantity);

            }
            return true;
        }

        public async Task<GoodReceipt> PostGoodReceiptAsync(GoodReceipt receipt)
        {
            await _context.Database.BeginTransactionAsync();

            await SetSupplierAsync(receipt);

            await CalculateReceiptAsync(receipt);

            BuildAccountPayableFromReceipt(receipt);

            await SetReceiptNcfAsync(receipt);

            await BuildPaymentFromInvoice(receipt);

            await SetReceiptNcfAsync(receipt);

            await UpdateStockAsync(receipt);

            await _context.AddAsync(receipt);
            await _context.SaveChangesAsync();

            await _context.Database.CommitTransactionAsync();

            return receipt;

        }
    }
}
