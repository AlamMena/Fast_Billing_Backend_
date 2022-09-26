using API.DbModels.Contexts;
using API.DbModels.Core;
using API.Dtos.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/")]
    public class CoreController<TModel, TDto> : ControllerBase
        where TModel : CoreModel
        where TDto : CoreDto

    {
        private readonly FbContext _context;
        private readonly IMapper _mapper;

        public CoreController(FbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [NonAction]
        public virtual async Task<bool> ValidateAsync(TDto request)
        {
            await Task.CompletedTask;

            return true;
        }

        [HttpGet("[controller]s")]
        public virtual async Task<IActionResult> GetAllAsync([FromQuery] int page, int limit)
        {
            var response = new PaginatedResponse<TDto>
            {
                Data = await _context.Set<TModel>()
                 .Skip((page - 1) * limit)
                 .Take(limit)
                 .ProjectTo<TDto>(_mapper.ConfigurationProvider)
                 .ToListAsync(),

                DataQuantity = await _context.Set<TModel>().CountAsync()
            };

            return Ok(response);
        }

        [HttpGet("[controller]/{id}")]
        public virtual async Task<IActionResult> GetByIdAsync(int id)
        {
            var dbEntity = await _context.Set<TModel>()
                .FirstOrDefaultAsync(d => d.Id == id);

            var responseEntity = _mapper.Map<TDto>(dbEntity);

            if (dbEntity is null)
            {
                return NotFound();
            }

            return Ok(responseEntity);
        }

        [HttpPost("[controller]")]
        public virtual async Task<IActionResult> PostAsync(TDto request)
        {
            await ValidateAsync(request);

            var dbEntity = _mapper.Map<TModel>(request);

            await _context.AddAsync(dbEntity);
            await _context.SaveChangesAsync();

            var responseEntity = _mapper.Map<TDto>(dbEntity);

            return Created("", responseEntity);

        }
        [HttpPut]
        public virtual async Task<IActionResult> PutAsync(TDto request)
        {
            var dbEntity = await _context.Set<TModel>().FindAsync(request.Id);

            if (dbEntity is null)
            {
                return NotFound();
            }

            _mapper.Map(request, dbEntity);

            await _context.SaveChangesAsync();

            var responseEntity = _mapper.Map<TDto>(dbEntity);

            return Ok(responseEntity);
        }

        [HttpDelete("[controller]/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var entity = await _context.Set<TModel>().FindAsync(id);
            if (entity is null)
            {
                return NotFound("resource not found");
            }

            entity.IsDeleted = true;

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

