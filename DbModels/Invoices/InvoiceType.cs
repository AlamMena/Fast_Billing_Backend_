using API.DbModels.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Invoices
{
    [Table("sales_invoices_types")]
    public class InvoiceType : CoreModel
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
