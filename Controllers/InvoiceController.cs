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

        private object GetPercentageByStatsus(IEnumerable<Invoice> src, IEnumerable<Invoice> dest)
        {
            var srcCount = src.Count() == 0 ? 1 : src.Count();
            var destCount = dest.Count() == 0 ? 1 : dest.Count();
            var m = (decimal)srcCount / destCount;
            return new
            {
                destCount,
                srcCount,
                total = (decimal)srcCount / (decimal)destCount
            };
        }

        [HttpPost("invoice/status")]
        public async Task<IActionResult> GetInvoiceStatus()
        {
            var invoices = await _context.Invoices.ToListAsync();

            var paidInvoices = invoices.Where(d => d.TotalPayed >= d.Total && d.Confirmed == true);
            var unpaidInvoices = invoices.Where(d => d.TotalPayed <= d.Total && d.Confirmed == true);
            var overdueInvoices = invoices.Where(d => d.CreditDates <= d.Date.Subtract(DateTime.Now).TotalDays);
            var shouldBePayedInvoices = invoices.Where(d => d.CreditDates >= d.Date.Subtract(DateTime.Now).TotalDays);
            var draftInvoices = invoices.Where(d => d.Confirmed == false);

            var response = new
            {
                global = new
                {
                    count = invoices.Count,
                    percentage = 100,
                    total = invoices.Sum(d => d.Total)
                },
                paid = new
                {
                    count = paidInvoices.Count(),
                    percentage = GetPercentageByStatsus(paidInvoices, invoices),
                    total = paidInvoices.Sum(d => d.Total),
                },
                unpaid = new
                {
                    count = unpaidInvoices.Count(),
                    percentage = GetPercentageByStatsus(unpaidInvoices, invoices),
                    total = unpaidInvoices.Sum(d => d.Total)
                },
                overdue = new
                {
                    count = overdueInvoices.Count(),
                    percentage = GetPercentageByStatsus(overdueInvoices, shouldBePayedInvoices),
                    total = overdueInvoices.Sum(d => d.Total)
                },
                draft = new
                {
                    count = draftInvoices.Count(),
                    percentage = GetPercentageByStatsus(invoices, draftInvoices),
                    total = draftInvoices.Sum(d => d.Total)
                }
            };

            return Ok(response);
        }


    }
}