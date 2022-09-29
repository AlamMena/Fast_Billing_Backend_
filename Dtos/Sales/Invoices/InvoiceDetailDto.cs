using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Sales.Invoices
{
    public class InvoiceDetailDto
    {
        [Range(0, double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int ProductId { get; set; }
        [Range(0.0, double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal Quantity { get; set; }
        public decimal Cost { get; set; }
        [Range(0.0, double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal Price { get; set; }
        public decimal Disccount { get; set; }
        public decimal Total { get; set; }
    }
}
