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

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api")]
    public class InvoiceController : CoreController<InvoiceDto, Invoice>
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _mapper;
        public InvoiceController(FbContext context, IMapper mapper, IInvoiceService invoiceService)
            : base(context, mapper)
        {
            _mapper = mapper;
            _invoiceService = invoiceService;
        }

        [HttpPost("invoice")]
        public async Task<IActionResult> PostInvoiceAsync(InvoiceDto request)
        {
            var mappedRequest = _mapper.Map<Invoice>(request);
            var invoice = await _invoiceService.PostInvoiceAsync(mappedRequest);
            var response = _mapper.Map<InvoiceDto>(invoice);

            return Ok(response);

        }

    }
}