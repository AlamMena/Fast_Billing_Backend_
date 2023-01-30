using System.ComponentModel.DataAnnotations;
using API.DbModels.Contexts;
using API.DbModels.Inventory.Suppliers;
using API.Dtos.Inventory.Suppliers;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class SupplierController : CoreController<Supplier, SupplierDto>
    {
        public SupplierController(FbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
        protected override async Task<bool> ValidateAsync(Supplier request)
        {
            var noIdentificationExists = await _context.Suppliers
                .AnyAsync(d => d.NoIdentification == request.NoIdentification && d.Id != request.Id);

            if (noIdentificationExists)
            {
                throw new ValidationException("The supplier identifaction is not valid");
            }
            return true;
        }

        [HttpGet("supplier/{id}")]
        public override async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await _context.Suppliers
                .Include(d => d.Contacts)
                .Include(d => d.Addresses)
                .ProjectTo<SupplierDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(d => d.Id == id);

            return Ok(response);
        }
    }
}
