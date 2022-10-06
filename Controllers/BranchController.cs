
using API.DbModels.Contexts;
using API.DbModels.System.Branches;
using API.Dtos.Core;
using API.Dtos.System.Branches;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

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
        protected override async Task<bool> ValidateAsync(Branch request)
        {
            var branchExists = await _context.Branches
                 .AnyAsync(d => d.Id != request.Id && d.Name == request.Name);
            if (branchExists)
            {
                throw new ValidationException("The branch name is not avaliable");
            }
            return true;
        }


        [HttpGet("branches")]
        public override async Task<IActionResult> GetAllFilteredAsync([FromQuery] PaginatedFilteredRequest request)
        {
            return await base.GetAllFilteredAsync(request);
        }
    }
}
