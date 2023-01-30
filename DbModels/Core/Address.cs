using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Core
{
    public class Address : CoreModel
    {
        public string Name { get; set; } = null!;
        public string Address1 { get; set; } = null!;
        public string? Address2 { get; set; }
        public string? PostalCode { get; set; }
        public string Country { get; set; } = null!;
        public string? Province { get; set; }
        public bool Main { get; set; }
    }
}
