using API.Dtos.Core;

namespace API.Dtos.Payments
{
    public class PaymentDto : CoreDto
    {
        public DateTime Date { get; set; }
        public int? CardNumber { get; set; }
        public int? BankId { get; set; }
        public int PaymentTypeId { get; set; }
        public decimal Amount { get; set; }
    }
}
