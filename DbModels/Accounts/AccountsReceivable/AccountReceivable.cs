using API.DbModels.Core;
using API.DbModels.Invoices;
using API.DbModels.Sales.Clients;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.AccountsReceivable
{
    [Table("accounts_receivable")]
    public class AccountReceivable : TenantModel
    {
        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;
        public string? ClientName { get; set; }
        public int? ClientDocNum { get; set; }
        public DateTime Date { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? Description { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public string Document { get; set; } = null!;
        public int Reference { get; set; }
        public bool Confirmed { get; set; }
        public int? InvoiceId { get; set; }
        public Invoice Invoice { get; set; } = null!;
        public ICollection<AccountReceivableTransaction> Transactions { get; set; }
        //public ICollection<ReciboDetalle> ReciboDetalles { get; set; }

        public AccountReceivable()
        {
            Transactions = new HashSet<AccountReceivableTransaction>();
            //ReciboDetalles = new HashSet<ReciboDetalle>();
        }
    }
}
