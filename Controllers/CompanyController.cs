using API.DbModels.Contexts;
using API.DbModels.System.Branches;
using API.DbModels.System.Companies;
using API.Dtos.Core;
using API.Dtos.System;
using API.Dtos.System.Companies;
using API.Services.Users;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    [ApiController]
    [Authorize]
    [Route("api")]
    public class CompanyController : ControllerBase
    {
        private readonly IUserManagement _userManagement;
        private readonly FbContext _context;
        private readonly IMapper _mapper;

        public CompanyController(IUserManagement userManagement, FbContext context, IMapper mapper)
        {
            _userManagement = userManagement;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("company")]
        public async Task<IActionResult> PostAsync(CompanyCreateDto request)
        {
            await _context.Database.BeginTransactionAsync();

            // mapping the dto to db model
            var company = _mapper.Map<Company>(request);

            // adding a default branch to the company
            company.Branches.Add(new Branch()
            {
                Name = "Principal",
                Location = request.Location,
                PhoneNumber = request.Location
            });

            // saving the new company
            await _context.AddAsync(company);
            await _context.SaveChangesAsync();

            // creating a new admin user
            company.Users.Add(await _userManagement.CreateUserAsync(request.Admin));

            // confirming all changes
            await _context.Database.CommitTransactionAsync();

            // mapping values to response
            var response = _mapper.Map<CompanyDto>(company);

            return Ok(response);
        }

        [HttpPut("company")]
        public async Task<IActionResult> UpdateCompanyAsync(CompanyDto request)
        {
            var company = await _context.Companies.FindAsync(request.Id);
            if (company is null)
            {
                return NotFound("Resource not found");
            }

            // mapping values from the request to the company
            _mapper.Map(request, company);

            // saving changes
            await _context.SaveChangesAsync();

            // mapping result
            _mapper.Map<CompanyDto>(company);

            return Ok();
        }


        [HttpGet("companies")]
        public async Task<IActionResult> GetCompaniesAsync([FromQuery] int page, int limit)
        {
            var response = new PaginatedResponse<Company>
            {
                Data = await _context.Companies
                 .Skip((page - 1) * limit)
                 .Take(limit)
                 .ToListAsync()
            };

            response.DataQuantity = await _context.Companies.CountAsync();

            return Ok(response);
        }



        [HttpGet("company/{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            return Ok(await _context.Companies.FindAsync(id));
        }
    }
}