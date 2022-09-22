using API.DbModels.Core;

namespace API.DbModels.Contacts
{
    public class Contact : TenantModel
    {
        public int TypeId { get; set; }
        public ContactType Type { get; set; } = null!;
        public bool AllowCredit { get; set; }
        public decimal CreditLimit { get; set; }
        public int CreditDays { get; set; }
        public bool AllowDisccount { get; set; }
        public decimal Disccount { get; set; }
        public int? DocNum { get; set; }
        public ICollection<ClientAddress> Addresses { get; set; }
        public ICollection<CuentaPorCobrar> CuentasPorCobrar { get; set; }
        public ICollection<ClienteTarjeta> Tarjetas { get; set; }
        public ICollection<ClienteContacto> Contactos { get; set; }
        public ICollection<Factura> Facturas { get; set; }

        public Cliente()
        {
            DireccionesEnvio = new HashSet<ClienteDireccionEnvio>();
            CuentasPorCobrar = new HashSet<CuentaPorCobrar>();
            Contactos = new HashSet<ClienteContacto>();
            Tarjetas = new HashSet<ClienteTarjeta>();
            Facturas = new HashSet<Factura>();

        }
    }
}
