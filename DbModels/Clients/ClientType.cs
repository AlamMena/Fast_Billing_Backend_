using API.DbModels.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Contacts
{
    [Table("sales_clients_types")]
    public class ClientType : CoreModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
