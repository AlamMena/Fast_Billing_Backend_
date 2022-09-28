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
        // public ICollection<ClientAddresses> Addresses { get; set; }
        // public ICollection<ClientCard> Cards { get; set; }
        // public ICollection<ClientContacts> Contacts { get; set; }
    }
}