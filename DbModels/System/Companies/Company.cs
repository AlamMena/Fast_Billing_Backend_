using API.DbModels.Core;
using API.DbModels.System.Branches;
using API.DbModels.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DbModels.System.Companies
{
    [Table("system_companies")]
    public class Company : CoreModel
    {
        public string Name { get; set; } = null!;
        public string NoIdentification { get; set; } = null!;
        public string? PostalCode { get; set; }
        public string Location { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; } = null!;
        public virtual ICollection<Branch> Branches { get; set; } = null!;


        public Company()
        {
            Users = new HashSet<User>();
            Branches = new HashSet<Branch>();
        }

    }
}
