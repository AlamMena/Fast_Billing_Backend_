namespace API.Dtos.Sales.Invoices
{
    public class InvoiceDto
    {
        public int InvoiceTypeId { get; set; }
        public int NcfTypeId { get; set; }
        public int CreditDates { get; set; }
        public int ClientId { get; set; }
        public bool WithTax { get; set; }
        public decimal TotalGrab { get; set; }
        public decimal Disccount { get; set; }
        public decimal TotalPayed { get; set; }
        public string? Note { get; set; }
        public bool Updated { get; set; }
        public ICollection<InvoiceDetailDto> Details { get; set; } 

        public InvoiceDto()
        {
            Details = new List<InvoiceDetailDto>();
        }
    }
}
