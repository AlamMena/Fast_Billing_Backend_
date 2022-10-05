using API.DbModels.Contexts;
using API.DbModels.Inventory.Products;
using API.DbModels.Products;
using API.Enums;
using API.Extensions;
using System.ComponentModel.DataAnnotations;

namespace API.Services.Inventory
{
    public class InventoryService
    {
        private readonly FbContext _context;
        public InventoryService(FbContext context)
        {
            _context = context;
        }
        public record StockTransactionRequest(Product Product, decimal Quantity, int WarehouseId);
        //    public async Task<bool> GenerateStockTransactionFromInvoiceAsync(Inv)
        //    {
        //        var currentStock = request.Product.Stocks
        //            .FirstOrDefault(d => d.WarehouseId == request.WarehouseId);

        //        // if the product stock is null we create a new stock
        //        if (currentStock == null)
        //        {
        //            var newStock = new ProductStock
        //            {
        //                WarehouseId = request.WarehouseId,
        //                Stock = request.Quantity,
        //            };

        //            request.Product.Stocks.Add(newStock);

        //            currentStock = newStock;
        //        }
        //        else
        //        {
        //            currentStock.Stock = product.Transactions
        //                .Where(d => d.WarehouseId == warehouseId && d.BranchId == _context.tenant.BranchId)
        //                .Sum(d => d.Quantity * (int)d.Sign);
        //        }

        //        product.Transactions.Add(new ProductTransaction
        //        {
        //            WarehouseId = currentStock.WarehouseId,
        //            ProductCost = product.Prices.First().Cost,
        //            ProductPrice = product.Prices.First().Price,
        //            ProductId = product.Id,
        //            Quantity = quantity,
        //            Sign = TransactionType.Outcome,
        //            OldQuantity = 0,
        //            NewQuantity = currentStock.Stock - quantity,
        //            NewCost = product.Prices.First().Cost,
        //            Note = "N/A",
        //            Document = AccountDocuments.Invoice.GetDocumentKey(),
        //            ExpirationDate = null,
        //            CompanyId = _context.tenant.CompanyId,
        //            BranchId = _context.tenant.BranchId,
        //        });

        //    //}
        ////}
    }
}
