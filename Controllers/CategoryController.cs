using API.DbModels.Contexts;
using API.DbModels.Inventory.Categories;
using API.Dtos.Inventory.Categories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    public class CategoryController : CoreController<Category, CategoryDto>
    {
        public CategoryController(FbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        protected override async Task<bool> ValidateAsync(Category request)
        {
            var categoryExists = await _context.Categories
                 .AnyAsync(d => d.Id != request.Id && d.Name == request.Name);
            if (categoryExists)
            {
                throw new ValidationException("The category name is not avaliable");
            }
            return true;
        }
        [HttpGet("categories")]
        public override async Task<IActionResult> GetAllAsync(int page, int limit)
        {
            return await base.GetAllAsync(page, limit);
        }

    }
}