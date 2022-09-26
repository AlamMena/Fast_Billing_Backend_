using API.DbModels.Core;
using API.DbModels.Inventory.Categories;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Inventory.SubCategories
{
    [Table("inventory_subcategories")]
    public class SubCategory : TenantModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;
    }
}
