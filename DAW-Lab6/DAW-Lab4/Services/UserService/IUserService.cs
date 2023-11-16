using DAW_Lab4.Models;
using DAW_Lab4.Models.DTOs;

namespace DAW_Lab4.Services.UserService
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsers();

        UserDto GetUserByUsername(string username);
    }
}
