using API.DbModels.Core;
using API.Enums;

namespace API.DbModels.Accounts.Core
{
    public class AccountTransaction : CoreModel
    {
        public DateTime Date { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Sign { get; set; }

        public string Document { get; set; } = null!;
        public int RefNo { get; set; }
    }
}