using API.DbModels.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Contacts
{
    [Table("sales_clients")]
    public class Client : TenantModel
    {
        public string Name { get; set; } = null!;
        public string? NoIdentification { get; set; }
        public string? Email { get; set; }
        public int TypeId { get; set; }
        public ClientType Type { get; set; } = null!;
        public bool AllowCredit { get; set; }
        public decimal CreditLimit { get; set; }
        public int CreditDays { get; set; }
        public bool AllowDisccount { get; set; }
        public decimal Disccount { get; set; }
        public ICollection<ClientAddresses> Addresses { get; set; }
        public ICollection<ClientCard> Cards { get; set; }
        public ICollection<ClientContacts> Contacts { get; set; }
        //public ICollection<CuentaPorCobrar> CuentasPorCobrar { get; set; }
        //public ICollection<Factura> Facturas { get; set; }

        public Client()
        {
            Addresses = new HashSet<ClientAddresses>();
            Cards = new HashSet<ClientCard>();
            Contacts = new HashSet<ClientContacts>();

            //Facturas = new HashSet<Factura>();
            //CuentasPorCobrar = new HashSet<CuentaPorCobrar>();


        }
    }
}
