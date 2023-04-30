using API.Dtos.Reports.Core;

namespace API.Services.Accounts.Reports
{
    public interface IAccountReportService
    {
        Task<ReportByDate> GetLastMonthBalanceByDay();
    }
}