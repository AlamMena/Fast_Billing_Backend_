using API.DbModels.Contexts;
using API.DbModels.System.Companies;
using AutoMapper;

namespace API.Controllers
{

    public class CompanyController : CoreController<Company, CompanyDto>
    {
        public CompanyController(FbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}