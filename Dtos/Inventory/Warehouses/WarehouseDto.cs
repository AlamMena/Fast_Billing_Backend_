using API.DbModels.Core;
using API.Dtos.Core;

namespace API.Dtos.Inventory.Warehouses
{
    public class WarehouseDto : CoreDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}