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
using API.Services.Sales.Invoices;
using API.Dtos.Core;
using AutoMapper.QueryableExtensions;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api")]
    public class InvoiceController : CoreController<Invoice, InvoiceDto>
    {
        private readonly IInvoiceService _invoiceService;
        public InvoiceController(FbContext context, IMapper mapper, IInvoiceService invoiceService)
            : base(context, mapper)
        {
            _invoiceService = invoiceService;
        }

        [HttpPost("invoice")]
        public override async Task<IActionResult> PostAsync(InvoiceDto request)
        {
            var mappedRequest = _mapper.Map<Invoice>(request);
            var invoice = await _invoiceService.PostInvoiceAsync(mappedRequest);
            var response = _mapper.Map<InvoiceDto>(invoice);

            return Ok(response);

        }

        [HttpPost("invoice/types")]
        public async Task<IActionResult> GetInvoiceTypesAsync()
        {
            var response = await _context.InvoiceTypes
                .ProjectTo<TypeDto>(_mapper.ConfigurationProvider).ToListAsync();

            return Ok(response);

        }

    }
}