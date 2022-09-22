using API.DbModels.Contexts;
using API.DbModels.Inventory.Categories;
using API.Dtos.Inventory.Categories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CategoryController : CoreController<Category, CategoryDto>
    {
        public CategoryController(FbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        [HttpGet("categories")]
        public override async Task<IActionResult> GetAllAsync(int page, int limit)
        {
            return await base.GetAllAsync(page, limit);
        }
    }
}