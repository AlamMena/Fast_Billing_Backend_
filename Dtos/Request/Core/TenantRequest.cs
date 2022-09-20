using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dtos.Request
{
    public class TenantRequest
    {
        public int CompanyId { get; set; }
        public string? BranchId { get; set; }
        public int UserId { get; set; }
        public string TokenId { get; set; } = null!;
    }
}
