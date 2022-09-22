namespace API.DbModels.Contacts
{
    public class ClientAddress
    {
        public string Name { get; set; } = null!;
        public string? PostalCode { get; set; }
        public string Country { get; set; } = null!;
        public string? Province { get; set; }
        public bool Main { get; set; }
    }
}
