using API.DbModels.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Inventory.Currencies
{
    [Table("system_currency")]
    public class Currency : CoreModel
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; }
    }
}
