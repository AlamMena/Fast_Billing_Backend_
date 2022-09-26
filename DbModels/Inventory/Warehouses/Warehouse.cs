using API.DbModels.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Inventory.Warehouses
{
    [Table("inventory_warehouses")]
    public class Warehouse : TenantModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
