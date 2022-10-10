using API.DbModels.Core;
using API.DbModels.Ncf;
using API.DbModels.Suppliers;
using API.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Accounts.AccountsPayable
{
    [Table("accounts_payable")]
    public class AccountPayable : TenantModel
    {
        public string? Ncf { get; set; }
        public DateTime Date { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Document { get; set; } = null!;
        public int Reference { get; set; }
        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public string SupplierName { get; set; } = null!;
        public string SupplierReceipt { get; set; } = null!;
        public string SupplierNoIdentification { get; set; } = null!;
        public int SupplierDocNum { get; set; }
        //public int? RecepcionMercanciaId { get; set; }
        //public RecepcionMercancia? RecepcionMercancia { get; set; }
        //public int CuentasPorPagarTipoId { get; set; }
        //public CuentaPorPagarTipo? CuentasPorPagarTipo { get; set; }
        public string Description { get; set; } = null!;
        public decimal SubTotal { get; set; }
        public decimal DisccountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Total { get; set; }
        public decimal Balance { get; set; }
        public bool Confirmed { get; set; }
        public ICollection<AccountPaybleTransaction> Transactions { get; set; }

        public AccountPayable()
        {
            Transactions = new HashSet<AccountPaybleTransaction>();
        }
    }
}
