namespace API.Dtos.Products
{
    public class ProductImageDto
    {
        public string Name { get; set; } = null!;
        public string Url { get; set; } = null!;
        public string? Description { get; set; }
    }
}
