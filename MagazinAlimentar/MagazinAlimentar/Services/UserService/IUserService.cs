using MagazinAlimentar.DTOs;
using MagazinAlimentar.Models;

namespace MagazinAlimentar.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        UserResponseDTO Authenticate(UserRequestDTO model);
        User GetById(Guid id);
        Task Create(User newUser);
    }
}
