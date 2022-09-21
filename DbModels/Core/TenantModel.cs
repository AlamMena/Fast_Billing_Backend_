using API.DbModels.System.Branches;
using API.DbModels.System.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DbModels.Core
{
    public class TenantModel : CoreModel
    {
        public Company Company { get; set; } = null!;
        public int? CompanyId { get; set; }
        public Branch Branch { get; set; } = null!;
        public int? BranchId { get; set; }
    }
}
