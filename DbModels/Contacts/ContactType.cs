using API.DbModels.Core;

namespace API.DbModels.Contacts
{
    public class ContactType : CoreModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
