using System.ComponentModel.DataAnnotations.Schema;

namespace API.DbModels.Core
{
    [Table("globals_contacts")]
    public class Contact : CoreModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Number { get; set; } = null!;
        public bool Main { get; set; }

    }
}
