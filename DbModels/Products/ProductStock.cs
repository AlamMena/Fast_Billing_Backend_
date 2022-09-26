using API.DbModels.Core;
using API.DbModels.Inventory.Warehouses;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Products
{
    [Table("inventory_products_stock")]
    public class ProductStock : TenantModel
    {
        public decimal Stock { get; set; }
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; } = null!;
        public int ProductId { get; set; }
        public Product Producto { get; set; } = null!;

    }
}
