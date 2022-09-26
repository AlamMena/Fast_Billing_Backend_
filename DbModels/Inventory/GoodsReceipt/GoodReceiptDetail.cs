using API.DbModels.Core;
using API.DbModels.Inventory.Warehouses;
using API.DbModels.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Inventory.GoodsReceipt
{
    [Table("inventory_goods_receipt_details")]
    public class GoodReceiptDetail : CoreModel
    {
        public string? ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal OldCost { get; set; }
        public decimal OldPrice { get; set; }
        public bool Exento { get; set; }
        public decimal MarginBenefit { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public decimal Disccount { get; set; }
        public decimal DisccountAmount { get; set; }
        public decimal Tax { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal Total { get; set; }
        public string? BuyUnity { get; set; }
        public decimal Empaque { get; set; }
        public string? SellUnity { get; set; }

        public int GoodReceiptId { get; set; }
        public virtual GoodReceipt GoodReceipt { get; set; } = null!;
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; } = null!;
        //public decimal Almacen { get; set; }
        //public decimal AlmacenAnterior { get; set; }
        //public int AlmacenId { get; set; }
        //public Almacen Almacen { get; set; } = null!;
        //public decimal PrecioVentaPublico { get; set; }
        //public bool FV { get; set; }
        //public bool Tipo { get; set; }
    }
}
