using API.DbModels.Contexts;
using API.DbModels.Inventory.SubCategories;
using API.Dtos.Inventory.SubCategories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    public class SubCategoryController : CoreController<SubCategory, SubCategoryDto>
    {
        private readonly FbContext _context;
        public SubCategoryController(FbContext context, IMapper mapper)
            : base(context, mapper)
        {
            _context = context;
        }

        [NonAction]
        public override async Task<bool> ValidateAsync(SubCategoryDto request)
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
        public override async Task<IActionResult> GetAllAsync(int page, int limit)
        {
            return await base.GetAllAsync(page, limit);
        }
    }
}
