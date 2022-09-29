using API.DbModels.AccountsReceivable;
using API.DbModels.Contacts;
using API.DbModels.Core;
using API.DbModels.Ncf;
using API.DbModels.Payments;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Invoices
{
    [Table("sales_invoices")]
    public class Invoice : TenantModel
    {
        public int InvoiceTypeId { get; set; }
        public InvoiceType Type { get; set; } = null!;
        public string? InvoiceTypeName { get; set; }
        public int? InvoiceNumber { get; set; }
        public int NcfTypeId { get; set; }
        public NcfType NcfType { get; set; } = null!;
        public string? NcfName { get; set; }
        public string Ncf { get; set; } = null!;
        public DateTime? NcfExpiration { get; set; }
        public DateTime NcfDate { get; set; }
        public DateTime Date { get; set; }
        public int CreditDates { get; set; }
        public int ClientId { get; set; }
        public Client Cliente { get; set; } = null!;
        public string? ClientNoIdentification { get; set; }
        public string? ClientName { get; set; } = null!;
        public string? ClientAddress { get; set; } = null!;
        public string? ClientEmail { get; set; }
        public string? ClientPhoneNumber { get; set; }
        public int? ClientCardId { get; set; }
        public ClientCard? ClientCard { get; set; }
        public string? ClientCardNo { get; set; }
        public string? ClientCardExpirationDate { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Tax { get; set; }
        public bool WithTax { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal ExcentTax { get; set; }
        public decimal TotalGrab { get; set; }
        public decimal SaveAmount { get; set; }
        public decimal AccountAmount { get; set; }
        public decimal Discount { get; set; }
        public bool Confirmed { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPayed { get; set; }
        public decimal Return { get; set; }
        public string? Note { get; set; }
        public bool Updated { get; set; }
        public ICollection<InvoiceDetail> Details { get; set; }
        public ICollection<AccountReceivable> AccountReceivables { get; set; }
        // public AccountReceivable Account { get; set; } = null!;
        public ICollection<Payment> Payments { get; set; }

        public Invoice()
        {
            Details = new HashSet<InvoiceDetail>();
            AccountReceivables = new HashSet<AccountReceivable>();
            Payments = new HashSet<Payment>();
        }

        //public string CajeroId { get; set; } = null!;
        //public Usuario Cajero { get; set; } = null!;
        //public string CajeroNombre { get; set; } = null!;
        //public int? MensajeroId { get; set; }
        //public ICollection<FormaPago> Pagos { get; set; }
        //public string? EnvioDireccion { get; set; }
        //public int EnvioSectorId { get; set; }
        //public string? EnvioSectorNombre { get; set; }
        //public int EnvioMunicipioId { get; set; }
        //public string? EnvioMunicipioNombre { get; set; }
        //public int AlmacenId { get; set; }
        //public Almacen Almacen { get; set; } = null!;
        //public string AlmacenNombre { get; set; } = null!;
        //public int? FacturadorId { get; set; }
        //public Facturador Facturador { get; set; } = null!;
        //public string? FacturadorNombre { get; set; }
        //public int? Entrega { get; set; }
        //public bool EntregaEstado { get; set; }
        //public int ClienteClasificacion { get; set; }
        //public string? ClienteEmpresaNombre { get; set; }
        //public string? ClienteNoCarnet { get; set; }

    }
}
