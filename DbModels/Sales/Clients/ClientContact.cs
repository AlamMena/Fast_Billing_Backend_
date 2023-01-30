using System.ComponentModel.DataAnnotations.Schema;
using API.DbModels.Core;

namespace API.DbModels.Sales.Clients
{
    [Table("sales_clients_contacts")]
    public class ClientContact : Contact
    {
        public Client Client { get; set; } = null!;
        public int ClientId { get; set; }
    }

}