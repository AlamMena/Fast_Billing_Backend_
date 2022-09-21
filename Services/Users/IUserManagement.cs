using API.DbModels.Users;
using API.Dtos.Users;

namespace API.Services.Users
{
    public interface IUserManagement
    {
        Task<User> CreateUserAsync(UserDto request);
        Task<User> UpdateUserAsync(UserDto request);
    }

}