using API.Dtos.Core;

namespace API.Dtos.Inventory.Categories
{
    public class CategoryDto : CoreDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }

}