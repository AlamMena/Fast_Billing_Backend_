using API.DbModels.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Payments
{
    [Table("globals_payments_types")]
    public class PaymentType : CoreModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; } 
    }
}
