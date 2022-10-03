using API.DbModels.Contexts;
using API.Dtos.Core;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [Route("api/[controller]")]
    public class NcfController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly FbContext _context;
        public NcfController(FbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("types")]
        public async Task<IActionResult> GetNcfTypesAsync()
        {
            var response = await _context.NcfTypes
                .ProjectTo<TypeDto>(_mapper.ConfigurationProvider).ToListAsync();
            return Ok(response);
        }
    }
}
