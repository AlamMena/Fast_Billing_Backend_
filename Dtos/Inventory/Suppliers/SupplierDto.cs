
using API.Dtos.Core;

namespace API.Dtos.Inventory.Suppliers
{
    public class SupplierDto : CoreDto
    {
        public string Name { get; set; } = null!;
        public string NoIdentification { get; set; } = null!;
        public string WebSite { get; set; } = null!;
        public string Descripction { get; set; } = null!;
        public decimal Discount { get; set; }
        public int? DaysToPay { get; set; }
        public int CurrencyId { get; set; }
        public List<AddressDto> Addresses { get; set; }
        public List<ContactDto> Contacts { get; set; }

        public SupplierDto()
        {
            Addresses = new List<AddressDto>();
            Contacts = new List<ContactDto>();
        }
    }
}
