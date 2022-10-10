using API.DbModels.Accounts.AccountsPayable;
using API.DbModels.Core;
using API.DbModels.Inventory.Warehouses;
using API.DbModels.Ncf;
using API.DbModels.Payments;
using API.DbModels.Suppliers;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Inventory.GoodsReceipt
{
    [Table("inventory_goods_receipt")]
    public class GoodReceipt : TenantModel
    {
        public DateTime Date { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; } = null!;
        public string? NumeroFactura { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; } = null!;
        public string? SupplierName { get; set; }
        public string? SupplierAddress { get; set; }
        public string? SupplierPhone { get; set; }
        public string SupplierNoIdentification { get; set; } = null!;
        public string? SupplierEmail { get; set; }
        public int Days { get; set; }
        public string? SellerName { get; set; }
        public bool Applied { get; set; }
        public int NcfTypeId { get; set; }
        public NcfType NcfType { get; set; } = null!;
        public string Ncf { get; set; } = null!;
        public string NcfName { get; set; } = null!;
        public string InvoiceNumber { get; set; } = null!;
        public string? InvoiceNcf { get; set; } = null!;
        public DateTime InvoiceDate { get; set; }
        public DateTime InvoiceExpirationDate { get; set; }
        public bool Confirmed { get; set; }
        public bool UpdateCost { get; set; }
        public bool UpdatePrice { get; set; }
        public bool? IncludeTaxes { get; set; }
        public decimal TypedSubtotal { get; set; }
        public decimal TypedDiscount { get; set; }
        public decimal TypedTotalTax { get; set; }
        public decimal TypedTotalCharge { get; set; }
        public decimal TypedTotal { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalPayed { get; set; }
        public decimal Return { get; set; }
        public decimal Tax { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalCharge { get; set; }
        public decimal Total { get; set; }
        public string? Note { get; set; }
        public int AccountId { get; set; }
        public AccountPayable Account { get; set; } = null!;
        public virtual ICollection<GoodReceiptDetail> Details { get; set; }
        public ICollection<Payment> Payments { get; set; }

        public GoodReceipt()
        {
            Details = new List<GoodReceiptDetail>();
            Payments = new HashSet<Payment>();
        }

        //public int AlmacenId { get; set; }
        //public Almacen Almacen { get; set; } = null!;
        //public string AlmacenNombre { get; set; } = null!;
        //public string AlmacenDireccion { get; set; } = null!;
        //public int TipoNumeracionId { get; set; }
        //public VentasNumeracion Numeracion { get; set; } = null!;
        //public int NumeracionId { get; set; }
        //public int Numerador { get; set; }
        //public string? TipoFacturaNombre { get; set; }
        //public int TipoFacturaId { get; set; }
        //public TipoFactura? TipoFactura { get; set; }
        //public ProveedorNCFTipo NCFTipo { get; set; } = null!;
        //public int? VendedorId { get; set; }
        //public Vendedor? Vendedor { get; set; }
        //public bool CodigoBarra { get; set; }
        //public bool PrintPrice { get; set; }
    }
}
