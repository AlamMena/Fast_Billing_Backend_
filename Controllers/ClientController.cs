using API.DbModels.Contacts;
using API.DbModels.Contexts;
using API.Dtos.Core;
using API.Dtos.Sales.Clients;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ClientController : CoreController<Client, ClientDto>
    {
        public ClientController(FbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        [HttpGet("clients/types")]
        public async Task<IActionResult> GetClientsTypesAsync()
        {
           var response =  await _context.ClientTypes
                    .ProjectTo<TypeDto>(_mapper.ConfigurationProvider).ToListAsync();

            return Ok(response);
        }
    }
}