using API.DbModels.Core;
using API.DbModels.Inventory.Warehouses;
using API.DbModels.Products;
using API.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Inventory.Products
{
    [Table("inventory_prodcuts_transactions")]
    public class ProductTransaction : TenantModel
    {
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; } = null!;
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public decimal ProductCost { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal Quantity { get; set; }
        public TransactionType Sign { get; set; } //tipo de movimiento; 1 = entró, -1 = salió
        public decimal OldQuantity { get; set; }
        public decimal OldCost { get; set; }
        public decimal NewQuantity { get; set; }
        public decimal NewCost { get; set; }
        public string Note { get; set; } = null!;
        public string Document { get; set; } = null!;
        public int DocumentReferenceId { get; set; }
        public DateTime? ExpirationDate { get; set; } //Fecha de vencimiento
    }
}
