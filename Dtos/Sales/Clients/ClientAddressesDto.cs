using API.Dtos.Core;

namespace API.Dtos.Sales.Clients
{
    public class ClientAddressesDto : CoreDto
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? PostalCode { get; set; }
        public string Country { get; set; } = null!;
        public string? Province { get; set; }
        public bool Main { get; set; }
    }
}
