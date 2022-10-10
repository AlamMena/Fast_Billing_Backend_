using API.DbModels.Contexts;
using API.DbModels.Suppliers;
using API.Dtos.Inventory.Suppliers;
using AutoMapper;

namespace API.Controllers
{
    public class SupplierController : CoreController<Supplier, SupplierDto>
    {
        public SupplierController(FbContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }
}
