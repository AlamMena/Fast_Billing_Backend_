namespace API.Dtos.Sales.Invoices
{
    public class InvoiceDetailDto
    {
     
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal Disccount { get; set; }
        public decimal Total { get; set; }
    }
}
