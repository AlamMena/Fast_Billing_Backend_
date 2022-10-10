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
        public bool AllowDiscount { get; set; }
        public decimal Discount { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<ClientCard> Cards { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        //public ICollection<CuentaPorCobrar> CuentasPorCobrar { get; set; }
        //public ICollection<Factura> Facturas { get; set; }

        public Client()
        {
            Addresses = new HashSet<Address>();
            Cards = new HashSet<ClientCard>();
            Contacts = new HashSet<Contact>();

            //Facturas = new HashSet<Factura>();
            //CuentasPorCobrar = new HashSet<CuentaPorCobrar>();


        }
    }
}
