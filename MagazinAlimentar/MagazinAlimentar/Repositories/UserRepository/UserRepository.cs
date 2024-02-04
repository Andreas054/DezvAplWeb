using MagazinAlimentar.Data;
using MagazinAlimentar.DTOs;
using MagazinAlimentar.Models;
using MagazinAlimentar.Models.Enums;
using MagazinAlimentar.Repositories.GenericRepository;

namespace MagazinAlimentar.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MagazinContext magazinContext) : base(magazinContext) { }

        public User FindByUsername(string username)
        {
            return _table.FirstOrDefault(x => x.UserName == username);
        }
    }
}
