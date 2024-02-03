using MagazinAlimentar.DTOs;
using MagazinAlimentar.Models;

namespace MagazinAlimentar.Services.UserService
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllUsers();

        public bool Create(UserDTO userDTO);
        UserDTO GetUserByName(string username);
    }
}
