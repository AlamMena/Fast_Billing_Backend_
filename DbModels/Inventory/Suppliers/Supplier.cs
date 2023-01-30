using API.DbModels.Core;
using API.DbModels.Inventory.Currencies;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Inventory.Suppliers
{
    [Table("inventory_suppliers")]
    public class Supplier : TenantModel
    {
        public string Name { get; set; } = null!;
        public string NoIdentification { get; set; } = null!;
        public string? WebSite { get; set; }
        public string? Descripction { get; set; }
        public string? Email { get; set; }
        public decimal Discount { get; set; }
        public int? DaysToPay { get; set; }
        public int CurrencyId { get; set; } = 1;
        public virtual Currency Currency { get; set; } = null!;
        //public int NCFTipoId { get; set; }
        public ICollection<SupplierAddress> Addresses { get; set; }
        public ICollection<SupplierContact> Contacts { get; set; }

        public Supplier()
        {
            Addresses = new HashSet<SupplierAddress>();
            Contacts = new HashSet<SupplierContact>();
        }
        //public ProveedorNCFTipo NCFTipo { get; set; } = null!;
        //public int TipoGastoId { get; set; }
        //public TipoGasto TipoGasto { get; set; } = null!;
        //public int TipoProveedorId { get; set; }
        //public TipoProveedor TipoProveedor { get; set; } = null!;
        //public ICollection<Vendedor> Vendedores { get; set; }
        //public ICollection<Marca> Marcas { get; set; }
    }
}
