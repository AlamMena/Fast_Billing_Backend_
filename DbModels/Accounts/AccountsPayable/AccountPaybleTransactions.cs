using API.DbModels.Accounts.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Accounts.AccountsPayable
{
    [Table("accounts_payable_transactions")]
    public class AccountPaybleTransaction : AccountTransaction
    {
        public int AccountPayableId { get; set; }
        public AccountPayable AccountPayable { get; set; } = null!;
    }
}
