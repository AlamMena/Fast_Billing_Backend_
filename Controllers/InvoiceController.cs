using API.DbModels.Contexts;
using API.DbModels.Invoices;
using API.Dtos.Sales.Invoices;
using API.Services.Sales.Ncf;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api")]
    public class InvoiceController : ControllerBase
    {
        private readonly FbContext _context;
        private readonly IMapper _mapper;
        private readonly INcfService _ncfService;
        public InvoiceController(FbContext context, IMapper mapper, INcfService ncfService)
        {
            _context = context;
            _mapper = mapper;
            _ncfService = ncfService;
        }

        private async Task<bool> ValidateAsync(InvoiceDto request)
        {
            var invoiceTypeExists = await _context.InvoiceTypes.AnyAsync(d => d.Id == request.InvoiceTypeId);
            if (!invoiceTypeExists)
            {
                throw new ValidationException("The invoice type is not valid");
            }

            var ncfTypeExists = await _context.NcfTypes.AnyAsync(d => d.Id == request.NcfTypeId);
            if (!invoiceTypeExists)
            {
                throw new ValidationException("The ncf type is not valid");
            }

            if (request.ClientId is not 0)
            {
                var clientExists = await _context.Clients.AnyAsync(d => d.Id == request.ClientId);
                if (clientExists)
                {
                    throw new ValidationException("The client is not valid");
                }
            }

            var productsAreRepeated = request.Details.GroupBy(d => d.ProductId).Any(d => d.Count() > 1);
            if (productsAreRepeated)
            {
                throw new ValidationException("Details repeated");
            }
            var productsIds = request.Details.Select(d => d.ProductId);
            var productsAreValid = !await _context.Products.Select(d => d.Id).Except(productsIds).AnyAsync();

            if (!productsAreValid)
            {
                throw new ValidationException("Products are not valid");
            }

            return true;
        }

        [AllowAnonymous]
        [HttpPost("invoice")]
        public async Task<IActionResult> PostInvoiceAsync(InvoiceDto request)
        {
            await ValidateAsync(request);

            await _context.Database.BeginTransactionAsync();

            var invoice = _mapper.Map<Invoice>(request);


            // getting invoice type name
            invoice.InvoiceTypeName = await _context.NcfTypes
                .Where(d => d.Id == request.NcfTypeId)
                .Select(d => d.Name)
                .FirstAsync();

            // ncf configuration
            var ncfResponse = await _ncfService.GetNcfAsync(request.InvoiceTypeId);
            invoice.Ncf = ncfResponse.Ncf;
            invoice.NcfExpiration = ncfResponse.ExpirationDate;

            // commiting changes
            await _context.AddAsync(invoice);
            await _context.SaveChangesAsync();

            _mapper.Map<InvoiceDto>(invoice);
            await _context.Database.CommitTransactionAsync();


            return Ok();
        }
    }
}