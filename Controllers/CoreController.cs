using API.DbModels.Contexts;
using API.DbModels.Core;
using API.Dtos.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Authorize]
[Route("api/[controller]")]
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

    private async Task<IActionResult> ValidateAsync(TDto request)
    {
        await Task.CompletedTask;

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page, int limit)
    {
        var response = new PaginatedResponse<TDto>();

        response.Data = await _context.Set<TModel>()
             .Skip((page - 1) * limit)
             .Take(limit)
             .ProjectTo<TDto>(_mapper.ConfigurationProvider)
             .ToListAsync();

        if (!response.Data.Any())
        {
            return NoContent();
        }

        response.DataQuantity = await _context.Set<TModel>().CountAsync();

        return Ok(response);
    }

    [HttpGet("/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromQuery] int id)
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

    [HttpPost]
    public async Task<IActionResult> UpsertAsync(TDto request)
    {
        await ValidateAsync(request);

        if (request.Id is 0)
        {
            var dbEntity = _mapper.Map<TModel>(request);

            await _context.AddAsync(dbEntity);
            await _context.SaveChangesAsync();

            var responseEntity = _mapper.Map<TDto>(dbEntity);

            return Ok(responseEntity);
        }
        else
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


    }
}