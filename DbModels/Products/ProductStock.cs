using API.DbModels.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Products
{
    [Table("inventory_products_stock")]
    public class ProductStock : TenantModel
    {
        //public int AlmacenId { get; set; }
        //public Almacen Almacen { get; set; } = null!;
        public decimal Stock { get; set; }

        public int ProductId { get; set; }
        public Product Producto { get; set; } = null!;

    }
}
