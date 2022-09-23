using API.DbModels.Core;
using API.DbModels.Inventory.Currencies;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Suppliers
{
    [Table("inventory_supplier")]
    public class Supplier : TenantModel
    {
        public string Name { get; set; } = null!;
        public string NoIdentification { get; set; } = null!;
        public string WebSite { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Descuento { get; set; }
        public int? Dias { get; set; }
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; } = null!;
        public int NCFTipoId { get; set; }
        //public ProveedorNCFTipo NCFTipo { get; set; } = null!;
        //public int TipoGastoId { get; set; }
        //public TipoGasto TipoGasto { get; set; } = null!;
        //public int TipoProveedorId { get; set; }
        //public TipoProveedor TipoProveedor { get; set; } = null!;
        //public ICollection<Vendedor> Vendedores { get; set; }
        //public ICollection<Marca> Marcas { get; set; }
    }
}
