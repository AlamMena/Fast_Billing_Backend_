using API.DbModels.Contacts;
using API.DbModels.Core;
using API.DbModels.Invoices;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.AccountsReceivable
{
    [Table("accounts_recivable")]
    public class AccountReceivable : TenantModel
    {
        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;
        public string? ClientName { get; set; }
        public int? ClientDocNum { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? Description { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public string Document { get; set; } = null!;
        public int Reference { get; set; }
        public int? ReferenceId { get; set; }
        public bool Confirmed { get; set; }
        public Invoice Invoice { get; set; }
        public ICollection<AccountReceivableTransaction> Transactions { get; set; }
        //public ICollection<ReciboDetalle> ReciboDetalles { get; set; }

        public AccountReceivable()
        {
            Transactions = new HashSet<AccountReceivableTransaction>();
            //ReciboDetalles = new HashSet<ReciboDetalle>();
        }
    }
}
