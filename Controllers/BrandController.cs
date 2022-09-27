using API.DbModels.Contexts;
using API.DbModels.Inventory.Brands;
using API.Dtos.Inventory.Brands;
using AutoMapper;

namespace API.Controllers
{
    public class BrandController : CoreController<Brand, BrandDto>
    {
        public BrandController(FbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}