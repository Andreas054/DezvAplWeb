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

        // create
        public void CreateDTO(UserDTO userDTO)
        {
           
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Name = userDTO.Name,
                Role = userDTO.Role
            };

            Create(newUser);
            Save();
        }

        public User FindByName(string name)
        {
            return _table.FirstOrDefault(u => u.Name.Equals(name));
        }

        public List<User> OrderByRole(string role)
        {
            // var usersOrderedAsc = _table.OrderBy(x => x.Role);
            // var usersOrderedDesc = _table.OrderByDescending(x => x.Role);

            // linq query syntax
            var usersOrderedAsc2 = from s in _table
                                   orderby s.Role
                                   select s;

            var usersOrderedDesc2 = from s in _table
                                    orderby s.Role descending
                                    select s;

            return usersOrderedAsc2.ToList();
        }

        public User Where(string role)
        {
            var result = from s in _table
                         where s.Role == role
                         select s;
            return (User)result;
        }

        public void GroupBy()
        {
            var groupedUsers = from s in _table
                               group s by s.Role;

            foreach (var user in groupedUsers)
            {
                Console.WriteLine("User " + user.Key);

                foreach (var s in user)
                {
                    Console.WriteLine("nume " + s.Name);
                }
            }
        }
    }
}
