using API.Dtos.Core;

namespace API.Dtos.Users
{
    public class UserDto : CoreDto
    {
        public string UserName { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}