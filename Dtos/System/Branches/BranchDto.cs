using API.Dtos.Core;

namespace API.Dtos.System.Branches
{
    public class BranchDto : CoreDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? PostalCode { get; set; }
        public string? Location { get; set; } = null!;
        public string? PhoneNumber { get; set; } = null!;

    }
}
