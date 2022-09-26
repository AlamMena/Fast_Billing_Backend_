using API.DbModels.Accounts.Core;
using API.DbModels.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.AccountsReceivable
{
    [Table("accounts_receivable_details")]
    public class AccountReceivableTransaction : CoreModel
    {
        public decimal Amount { get; set; }
        public AccountSign Sign { get; set; }
        public string Document { get; set; } = null!;
        public int AccounReceivabletId { get; set; }
        public AccountReceivable Account { get; set; } = null!;
        public int Reference { get; set; }

    }
}
