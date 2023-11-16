using DAW_Lab4.Data;
using DAW_Lab4.Helpers.Extensions;
using DAW_Lab4.Models;
using DAW_Lab4.Repositories.GenericRepository;

namespace DAW_Lab4.Repositories.UserRepository
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(Lab4Context lab4Context) : base(lab4Context)
        {
        }

        public List<User> FindAllActive()
        {
            return _table.GetActiveUsers().ToList();
        }

        public User FindByUsername(string username)
        {
            return _table.FirstOrDefault(u => u.Username.Equals(username));
        }
    }
}
