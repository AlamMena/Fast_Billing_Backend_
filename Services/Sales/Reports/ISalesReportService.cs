using API.Dtos.Reports.Core;

namespace API.Services.Sales.Reports
{
    public interface ISalesReportService
    {
        Task<ReportByDate> GetLastMonthSalesByDayAsync();
        Task<ReportByDate> GetLastMonthProductsQuantitySoldByDay();

    }

}