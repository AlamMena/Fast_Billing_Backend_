using API.DbModels.Contexts;
using API.DbModels.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class CoreController<TModel, TRequest> : ControllerBase
where TModel : CoreModel
where TRequest : EntityRequest

{
    private readonly FbContext _context;
    private readonly IMapper _mapper;

    public CoreController(FbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    private async Task<IActionResult> ValidateAsync(TRequest request)
    {
        await Task.CompletedTask;

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page, int limit)
    {
        var response = new PaginatedResponse<TRequest>();

        response.Data = await _context.Set<TModel>()
             .Skip((page - 1) * limit)
             .Take(limit)
             .ProjectTo<TRequest>(_mapper.ConfigurationProvider)
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

        var responseEntity = _mapper.Map<TRequest>(dbEntity);

        if (dbEntity is null)
        {
            return NotFound();
        }

        return Ok(responseEntity);
    }

    [HttpPost]
    public async Task<IActionResult> UpsertAsync(TRequest request)
    {
        await ValidateAsync(request);

        if (request.Id is 0)
        {
            var dbEntity = _mapper.Map<TModel>(request);
            await _context.AddAsync(dbEntity);

            var responseEntity = _mapper.Map<TRequest>(dbEntity);

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

            var responseEntity = _mapper.Map<TRequest>(dbEntity);

            return Ok(responseEntity);
        }

    }
}