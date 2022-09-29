namespace API.Dtos.Core
{
    public class TypeDto : CoreDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
