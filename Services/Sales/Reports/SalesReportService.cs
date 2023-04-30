using System.Reflection.Emit;
using API.DbModels.Contexts;
using API.Dtos.Reports.Core;
using DecimalExtensions;
using Microsoft.EntityFrameworkCore;
using API.Enums;

namespace API.Services.Sales.Reports
{
    public class SalesReportService : ISalesReportService
    {
        private readonly FbContext _context;
        public SalesReportService(FbContext context)
        {
            _context = context;
        }
        public async Task<ReportByDate> GetLastMonthSalesByDayAsync()
        {
            var salesThisMonthGroupByDay = await _context.AccountReceivableTransactions
               .Where(d => d.Date.Year == DateTime.Now.Year
                        && d.Date.Month == DateTime.Now.Month
                        && d.Sign == TransactionType.Income)
               .GroupBy(d => d.Date.Day)
               .Select(d => new ReportByDateDetail
               {
                   Date = d.First().Date,
                   Value = d.Sum(d => d.Amount)
               })
               .ToListAsync();


            var salesYesterday = salesThisMonthGroupByDay.Where(d => d.Date.Day == new DateTime().Day - 1).Sum(d => d.Value);
            var salesToday = salesThisMonthGroupByDay.Where(d => d.Date.Day == new DateTime().Day).Sum(d => d.Value);

            var response = new ReportByDate
            {
                Label = "Sales Profit",
                Data = salesThisMonthGroupByDay,
                Total = salesThisMonthGroupByDay.Sum(d => d.Value),
                IncreasePercentage = salesYesterday.GetIncreasePercentage(salesToday)
            };

            return response;
        }

        public async Task<ReportByDate> GetLastMonthPurchasesByDayAsync()
        {
            var purchasesThisMonthGroupByDay = await _context.AccountsPaybleTransactions
               .Where(d => d.Date.Year == DateTime.Now.Year && d.Date.Month == DateTime.Now.Month)
               .GroupBy(d => d.Date.Day)
               .Select(d => new ReportByDateDetail
               {
                   Date = d.First().Date,
                   Value = d.Sum(d => d.Amount)
               })
               .ToListAsync();


            var pucharsesYesterday = purchasesThisMonthGroupByDay.Where(d => d.Date.Day == new DateTime().Day - 1).Sum(d => d.Value);
            var pucharsesToday = purchasesThisMonthGroupByDay.Where(d => d.Date.Day == new DateTime().Day).Sum(d => d.Value);

            var response = new ReportByDate
            {
                Label = "Sales Profit",
                Data = purchasesThisMonthGroupByDay,
                Total = pucharsesToday,
                IncreasePercentage = pucharsesYesterday.GetIncreasePercentage(pucharsesYesterday)
            };

            return response;
        }



        public async Task<ReportByDate> GetLastMonthProductsQuantitySoldByDay()
        {
            var productsSoldThisMonthGroupByDay = await _context.InvoiceDetails
              .Include(d => d.Invoice)
              .Where(d => d.Invoice.Date.Year == DateTime.Now.Year && d.Invoice.Date.Month == DateTime.Now.Month)
              .GroupBy(d => d.Invoice.Date.Day)
              .Select(d => new ReportByDateDetail
              {
                  Date = d.First().Invoice.Date,
                  Value = d.Sum(d => d.Quantity)
              })
              .ToListAsync();

            var productSoldYesterday = productsSoldThisMonthGroupByDay.Where(d => d.Date.Day == new DateTime().Day - 1).Sum(d => d.Value);
            var productSoldToday = productsSoldThisMonthGroupByDay.Where(d => d.Date.Day == new DateTime().Day).Sum(d => d.Value);

            var response = new ReportByDate
            {
                Label = "Products Sold",
                Data = productsSoldThisMonthGroupByDay,
                Total = productsSoldThisMonthGroupByDay.Sum(d => d.Value),
                IncreasePercentage = productSoldYesterday.GetIncreasePercentage(productSoldToday)
            };

            return response;
        }
    }
}