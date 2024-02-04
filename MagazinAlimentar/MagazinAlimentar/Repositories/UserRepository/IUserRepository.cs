using MagazinAlimentar.DTOs;
using MagazinAlimentar.Models;
using MagazinAlimentar.Models.Enums;
using MagazinAlimentar.Repositories.GenericRepository;

namespace MagazinAlimentar.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User FindByUsername(string username);
    }
}
