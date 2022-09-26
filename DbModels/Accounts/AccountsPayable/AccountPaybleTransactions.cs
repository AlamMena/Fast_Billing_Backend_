using API.DbModels.Core;
using API.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Accounts.AccountsPayable
{
    [Table("accounts_payable_transactions")]
    public class AccountPaybleTransaction : CoreModel
    {
        public DateTime Date { get; set; }
        public decimal DisccountAmount { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Sign { get; set; }
        public int AccountPayableId { get; set; }
        public AccountPayable AccountPayable { get; set; } = null!;
        public string Document { get; set; } = null!;
        public int RefNo { get; set; }
    }
}
