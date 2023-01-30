using API.DbModels.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Sales.Clients
{
    [Table("sales_clients_cards")]
    public class ClientCard : CoreModel
    {
        public string CardName { get; set; } = null!;
        public string LastDigits { get; set; } = null!;
        public string ExpirationDate { get; set; } = null!;

        public int ClientId { get; set; }
        public virtual Client Client { get; set; } = null!;
    }
}
