﻿using API.DbModels.Contexts;
using API.DbModels.Inventory.SubCategories;
using API.Dtos.Core;
using API.Dtos.Inventory.SubCategories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    public class SubCategoryController : CoreController<SubCategory, SubCategoryDto>
    {
        public SubCategoryController(FbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        protected override async Task<bool> ValidateAsync(SubCategory request)
        {
            var subcatagoryExists = await _context.SubCategories.AnyAsync(d => d.Id != request.Id && d.Name == request.Name);
            if (subcatagoryExists)
            {
                throw new ValidationException("The subcategory name is not avaliable");
            }
            var categoryExists = await _context.Categories.AnyAsync(d => d.Id == request.CategoryId);
            if (!categoryExists)
            {
                throw new ValidationException("The category is not valid");
            }

            return true;
        }

        [HttpGet("subcategories")]
        public override async Task<IActionResult> GetAllFilteredAsync([FromQuery] PaginatedFilteredRequest request)
        {
            return await base.GetAllFilteredAsync(request);
        }


        [HttpGet("subcategory/{id}")]
        public override async Task<IActionResult> GetByIdAsync(int id)
        {
            var dbEntity = await _context.SubCategories
                .Include(d => d.Category)
                .FirstOrDefaultAsync(d => d.Id == id);

            var responseEntity = _mapper.Map<SubCategoryDto>(dbEntity);

            if (dbEntity is null)
            {
                return NotFound();
            }

            return Ok(responseEntity);
        }
    }
}
