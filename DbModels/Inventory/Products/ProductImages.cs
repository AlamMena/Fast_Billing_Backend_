using API.DbModels.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Products
{
    [Table("inventory_products_images")]
    public class ProductImage : CoreModel
    {
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
        public string? Description { get; set; }
    }
}
