using API.Dtos.Users;

namespace API.Dtos.System
{
    public class CompanyCreateDto
    {
        public string Name { get; set; } = null!;
        public string NoIdentification { get; set; } = null!;
        public string? PostalCode { get; set; }
        public string Location { get; set; } = null!;
        public UserDto Admin { get; set; } = null!;
    }

}