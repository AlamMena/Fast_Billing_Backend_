using API.DbModels.Contexts;
using API.DbModels.Inventory.Warehouses;
using API.Dtos.Inventory.Warehouses;
using AutoMapper;

namespace API.Controllers
{
    public class WarehouseController : CoreController<Warehouse, WarehouseDto>
    {
        public WarehouseController(FbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}