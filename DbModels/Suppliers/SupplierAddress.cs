using API.DbModels.Core;

namespace API.DbModels.Suppliers
{
    public class SupplierAddress : CoreModel
    {
        public string Name { get; set; } = null!;
        public string? PostalCode { get; set; }
        public string Country { get; set; } = null!;
        public string? Province { get; set; }
        public bool Main { get; set; }
    }
}
