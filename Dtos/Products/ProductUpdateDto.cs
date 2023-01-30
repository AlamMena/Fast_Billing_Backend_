using API.Dtos.Core;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Products
{
    public class ProductUpdateDto : CoreDto
    {
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string AbName { get; set; } = null!;
        public string BarCode { get; set; } = null!;
        public int BrandId { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public decimal Capacity { get; set; }
        public string? Location { get; set; }
        public string? Origin { get; set; }
        public decimal? Large { get; set; }
        public decimal? Anchor { get; set; }
        public string? Size { get; set; }
        public bool HasTax { get; set; }
        public decimal Tax { get; set; }
        public bool OnStock { get; set; }
        public List<ProductImageDto> Images { get; set; } = null!;
    }
}
