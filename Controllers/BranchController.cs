
using API.DbModels.Contexts;
using API.DbModels.System.Branches;
using API.Dtos.System.Branches;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    public class BranchController : CoreController<Branch, BranchDto>
    {
        public BranchController(FbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        [HttpGet("branches")]
        public override async Task<IActionResult> GetAllAsync([FromQuery] int page, int limit)
        {
            return await base.GetAllAsync(page, limit);
        }

    }
}
