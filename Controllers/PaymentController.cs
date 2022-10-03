using API.DbModels.Contexts;
using API.Dtos.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly FbContext _context;
        private readonly IMapper _mapper;

        public PaymentController(FbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetPaymentTypesAsync()
        {
            var response = await _context.PaymentTypes
                .ProjectTo<TypeDto>(_mapper.ConfigurationProvider).ToListAsync();

            return Ok(response);
        }
    }
}