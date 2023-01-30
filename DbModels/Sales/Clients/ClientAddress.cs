using System.ComponentModel.DataAnnotations.Schema;
using API.DbModels.Core;

namespace API.DbModels.Sales.Clients
{
    [Table("sales_clients_addresses")]
    public class ClientAddress : Address
    {
        public Client Client { get; set; } = null!;
        public int ClientId { get; set; }
    }
}