using System.ComponentModel.DataAnnotations;
using API.DbModels.Contexts;
using API.DbModels.Sales.Clients;
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

        protected override async Task<bool> ValidateAsync(Client request)
        {
            var noIdentificationExists = await _context.Clients
                .AnyAsync(d => d.NoIdentification == request.NoIdentification && d.Id != request.Id);

            if (noIdentificationExists)
            {
                throw new ValidationException("The client identifaction is not valid");
            }
            return true;
        }

        [HttpGet("clients/types")]
        public async Task<IActionResult> GetClientsTypesAsync()
        {
            var response = await _context.ClientTypes
                     .ProjectTo<TypeDto>(_mapper.ConfigurationProvider).ToListAsync();

            return Ok(response);
        }

        [HttpGet("client/{id}")]
        public override async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await _context.Clients
                .Include(d => d.Contacts)
                .Include(d => d.Addresses)
                .ProjectTo<ClientDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(d => d.Id == id);

            return Ok(response);
        }
    }
}