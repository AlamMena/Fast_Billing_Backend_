namespace API.Dtos.Core
{
    public class AddressDto : CoreDto
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? PostalCode { get; set; }
        public string Country { get; set; } = null!;
        public string? Province { get; set; }
        public bool Main { get; set; }
    }
}
