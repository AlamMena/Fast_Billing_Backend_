using API.DbModels.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Contacts
{
    [Table("sales_clients_addresses")]
    public class ClientAddresses : CoreModel
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? PostalCode { get; set; }
        public string Country { get; set; } = null!;
        public string? Province { get; set; }
        public bool Main { get; set; }
        
        public int ClientId { get; set; }
        public virtual Client Client { get; set; } = null!;
    }
}
