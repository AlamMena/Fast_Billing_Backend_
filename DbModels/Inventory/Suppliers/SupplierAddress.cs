using System.ComponentModel.DataAnnotations.Schema;
using API.DbModels.Core;

namespace API.DbModels.Inventory.Suppliers
{
    [Table("inventory_suppliers_addresses")]
    public class SupplierAddress : Address
    {
        public Supplier Supplier { get; set; } = null!;
        public int SupplierId { get; set; }
    }
}