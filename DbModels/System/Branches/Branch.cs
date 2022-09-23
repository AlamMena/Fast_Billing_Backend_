using API.DbModels.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DbModels.System.Branches
{
    [Table("system_branches")]
    public class Branch : CoreModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? PostalCode { get; set; }
        public string Location { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
