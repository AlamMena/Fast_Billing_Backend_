using API.DbModels.Core;
using API.DbModels.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Invoices
{
    [Table("sales_invoices_details")]
    public class InvoiceDetail : CoreModel
    {
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; } = null!;
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public decimal Quantity { get; set; }
        public decimal Offert { get; set; }
        public bool Excent { get; set; }
        public decimal Cost { get; set; }
        public decimal Avarage { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal Tax { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Total { get; set; }
        //public int TipoMovimientoId { get; set; }
        //public int Tipo { get; set; }
        public decimal Comision { get; set; }
        public string? SellUnity { get; set; }
        public bool Pending { get; set; }
    }
}
