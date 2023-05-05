using API.DbModels.Contexts;
using API.Dtos.Reports.Core;
using DecimalExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Accounts.Reports
{
    public class AccountsReportService : IAccountReportService
    {
        private readonly FbContext _context;

        public AccountsReportService(FbContext context)
        {
            _context = context;
        }

        private async Task<List<ReportByDateDetail>> GetAllTransactionsOfCurrentMonth()
        {
            var response = await _context.AccountsPaybleTransactions.Select(d => new // profit transactions
            {
                d.Date,
                d.Amount,
                d.Sign

            }).Union(_context.AccountReceivableTransactions.Select(d => new // loss transactions
            {
                d.Date,
                d.Amount,
                d.Sign

            }))
           .Where(d => d.Date.Month == DateTime.Now.Month && d.Date.Year == DateTime.Now.Year)
           .GroupBy(d => d.Date.Day)
           .Select(d => new ReportByDateDetail
           {
               Date = d.First().Date,
               Value = d.Sum(d => d.Amount * (int)d.Sign)
           })
           .ToListAsync();

            return response;
        }
        public async Task<ReportByDate> GetLastMonthBalanceByDay()
        {
            var transactions = await GetAllTransactionsOfCurrentMonth();

            var balanceYesterday = transactions.Where(d => d.Date.Day == DateTime.Now.Day - 1).Sum(d => d.Value);
            var balanceToday = transactions.Where(d => d.Date.Day == DateTime.Now.Day).Sum(d => d.Value);

            var response = new ReportByDate
            {
                Label = "Total Balance",
                Data = transactions,
                Total = transactions.Sum(d => d.Value),
                IncreasePercentage = balanceYesterday.GetIncreasePercentage(balanceToday),
            };

            return response;
        }

        // public async Task<ReportByDate> GetLastMonthBalanceByDay()
        // {
        //     var totalBalanceThisMonthByDay = await _context.AccountsPaybleTransactions.Select(d => new // profit transactions
        //     {
        //         date = d.Date,
        //         amount = d.Amount,
        //         sign = d.Sign

        //     }).Union(_context.AccountReceivableTransactions.Select(d => new // loss transactions
        //     {
        //         date = d.Date,
        //         amount = d.Amount,
        //         sign = d.Sign

        //     }))
        //    .GroupBy(d => d.date.Day)
        //    .Select(d => new ReportByDateDetail
        //    {
        //        Date = d.First().date,
        //        Value = d.Sum(d => d.amount * (int)d.sign)
        //    })
        //    .ToListAsync();

        //     var balanceYesterday = totalBalanceThisMonthByDay.Where(d => d.Date.Day == DateTime.Now.Day - 1).Sum(d => d.Value);
        //     var balanceToday = totalBalanceThisMonthByDay.Where(d => d.Date.Day == DateTime.Now.Day - 1).Sum(d => d.Value);

        //     var response = new ReportByDate
        //     {
        //         Label = "Total Balance",
        //         Data = totalBalanceThisMonthByDay,
        //         Total = totalBalanceThisMonthByDay.Sum(d => d.Value),
        //         IncreasePercentage = balanceYesterday.GetIncreasePercentage(balanceToday),
        //     };

        //     return response;
        // }

        public async Task<object> GetLastMonthTransactionsGroupByType()
        {
            var totalBalanceThisMonthByDay = await _context.AccountsPaybleTransactions.Select(d => new // profit transactions
            {
                date = d.Date,
                amount = d.Amount,
                sign = d.Sign

            }).Union(_context.AccountReceivableTransactions.Select(d => new // loss transactions
            {
                date = d.Date,
                amount = d.Amount,
                sign = d.Sign

            }))
           .GroupBy(d => d.date.Day)
           .Select(d => new ReportByDateDetail
           {
               Date = d.First().date,
               Value = d.Sum(d => d.amount * (int)d.sign)
           })
           .ToListAsync();

            var balanceYesterday = totalBalanceThisMonthByDay.Where(d => d.Date.Day == DateTime.Now.Day - 1).Sum(d => d.Value);
            var balanceToday = totalBalanceThisMonthByDay.Where(d => d.Date.Day == DateTime.Now.Day - 1).Sum(d => d.Value);

            var response = new ReportByDate
            {
                Label = "Total Balance",
                Data = totalBalanceThisMonthByDay,
                Total = totalBalanceThisMonthByDay.Sum(d => d.Value),
                IncreasePercentage = balanceYesterday.GetIncreasePercentage(balanceToday),
            };

            return response;
        }
    }
}