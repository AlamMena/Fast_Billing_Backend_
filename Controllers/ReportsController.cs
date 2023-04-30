using System.Reflection.Emit;
using API.DbModels.Contexts;
using API.Dtos.Reports.Core;
using API.Services.Accounts.Reports;
using API.Services.Sales.Reports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly FbContext _context;
        private ISalesReportService _salesReportService;
        private IAccountReportService _accountReportService;
        public ReportsController(FbContext context, ISalesReportService salesReportService, IAccountReportService accountReportService)
        {
            _context = context;
            _salesReportService = salesReportService;
            _accountReportService = accountReportService;
        }



        [HttpGet("index/status")]
        public async Task<IActionResult> GetIndexStatus()
        {
            var productSoldReport = await _salesReportService.GetLastMonthProductsQuantitySoldByDay();
            var salesReport = await _salesReportService.GetLastMonthSalesByDayAsync();
            var profitReport = await _accountReportService.GetLastMonthBalanceByDay();
            var response = new List<ReportByDate> { productSoldReport, salesReport, profitReport };

            return Ok(response);
        }
    }

}