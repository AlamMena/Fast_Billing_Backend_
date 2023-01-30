using System.ComponentModel.DataAnnotations.Schema;
using API.DbModels.Core;

namespace API.DbModels.Inventory.Suppliers
{
    [Table("inventory_suppliers_contacts")]
    public class SupplierContact : Contact
    {
        public Supplier Supplier { get; set; } = null!;
        public int SupplierId { get; set; }

    }

}