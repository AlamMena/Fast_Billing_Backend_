using API.Dtos.Core;

namespace API.Dtos.Inventory.SubCategories
{
    public class SubCategoryDto : CoreDto
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

    }
}
