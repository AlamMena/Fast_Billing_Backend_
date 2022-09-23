using API.DbModels.Core;

namespace API.DbModels.Suppliers
{
    public class SupplierContacts : CoreModel
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Number { get; set; }

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } = null!;
    }
}
