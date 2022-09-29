namespace API.Services.Sales.Invoices
{
    public interface IInvoiceService
    {
        Task<InvoiceDto> PostInvoiceAsync(InvoiceDto request);
    }
}