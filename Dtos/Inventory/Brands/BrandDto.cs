using API.Dtos.Core;

namespace API.Dtos.Inventory.Brands
{
    public class BrandDto : CoreDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}