using API.DbModels.Core;
using API.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Payments
{
    [Table("globals_payments")]
    public class Payment : TenantModel
    {
        public DateTime Date { get; set; }
        public int? CardNumber { get; set; }
        public int? BankId { get; set; }
        public Bank? Bank { get; set; }
        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; } = null!;
        public string Document { get; set; } = null!;
        public int Reference { get; set; }
        public int ReferenceId { get; set; }
        public decimal Amount { get; set; }
    }
}
