using API.Dtos.Core;

namespace API.Dtos.Sales.Clients
{
    public class ClientDto : CoreDto
    {
        public string Name { get; set; } = null!;
        public string? NoIdentification { get; set; }
        public string? Email { get; set; }
        public int TypeId { get; set; }
        public bool AllowCredit { get; set; }
        public decimal CreditLimit { get; set; }
        public int CreditDays { get; set; }
        public bool AllowDisccount { get; set; }
        public decimal Disccount { get; set; }
        public List<AddressDto> Addresses { get; set; }
        public List<ContactDto> Contacts { get; set; }
        // public ICollection<ClientCard> Cards { get; set; }

        public ClientDto()
        {
            Addresses = new List<AddressDto>();
            Contacts = new List<ContactDto>();
        }
    }
}