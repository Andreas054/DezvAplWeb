using MagazinAlimentar.Models.Base;
using MagazinAlimentar.Models.Enums;
using System.Text.Json.Serialization;

namespace MagazinAlimentar.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        // public string Role { get; set; }

        public Role Role { get; set; }

        public UserDates? UserDates { get; set; }
    }
}
