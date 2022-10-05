using API.DbModels.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Contacts
{
    [Table("sales_clients_contacts")]
    public class ClientContacts : CoreModel
    {
        public string Name { get; set; } = null!;
        public string Number { get; set; } = null!;

        public int ClientId { get; set; }
        public virtual Client Client { get; set; } = null!;
    }
}
