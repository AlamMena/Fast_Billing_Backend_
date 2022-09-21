using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dtos.Core
{
    public class TenantRequest
    {
        public int? CompanyId { get; set; }
        public int? BranchId { get; set; }
        public int UserId { get; set; }
        public string TokenId { get; set; } = null!;
    }
}
