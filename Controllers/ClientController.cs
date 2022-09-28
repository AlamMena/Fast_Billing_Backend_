using API.DbModels.Contacts;
using API.DbModels.Contexts;
using API.Dtos.Sales.Clients;
using AutoMapper;

namespace API.Controllers
{
    public class ClientController : CoreController<Client, ClientDto>
    {
        public ClientController(FbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}