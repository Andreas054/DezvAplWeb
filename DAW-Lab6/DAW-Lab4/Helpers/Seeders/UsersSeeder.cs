using Azure.Identity;
using DAW_Lab4.Data;
using DAW_Lab4.Models;
using System.ComponentModel.DataAnnotations;

namespace DAW_Lab4.Helpers.Seeders
{
    public class UsersSeeder
    {
        public readonly Lab4Context _lab4Context;

        public UsersSeeder(Lab4Context lab4Context)
        {
            _lab4Context = lab4Context;
        }

        public void SeedInitialUsers()
        {
            if (!_lab4Context.Users.Any())
            {
                var user1 = new User
                {
                    FirstName = "First name User 1",
                    LastName = "Last name User 1",
                    IsDeleted = false,
                    EmailAddressAttribute = "user1@gmail.com",
                    Username = "user1"
                };

                var user2 = new User
                {
                    FirstName = "First name User 2",
                    LastName = "Last name User 2",
                    IsDeleted = false,
                    EmailAddressAttribute = "user2@gmail.com",
                    Username = "user2"
                };

                _lab4Context.Users.Add(user1);
                _lab4Context.Users.Add(user2);

                _lab4Context.SaveChanges();
            }
        }
    }
}
