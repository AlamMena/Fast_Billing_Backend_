using API.DbModels.Invoices;

namespace API.Services.Sales.Invoices
{
    public interface IInvoiceService
    {
        Task<Invoice> PostInvoiceAsync(Invoice request);
    }
}