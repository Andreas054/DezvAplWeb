using MagazinAlimentar.DTOs;
using MagazinAlimentar.Models;
using MagazinAlimentar.Models.Enums;
using MagazinAlimentar.Repositories.GenericRepository;

namespace MagazinAlimentar.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public void CreateDTO(UserDTO userDTO);
        User FindByName(string name);
        public List<User> OrderByRole(string role);
    }
}
