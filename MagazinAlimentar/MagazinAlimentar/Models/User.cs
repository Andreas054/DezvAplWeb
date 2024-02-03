using MagazinAlimentar.Models.Base;
using MagazinAlimentar.Models.Enums;

namespace MagazinAlimentar.Models
{
    public class User : BaseEntity
    {
        public DateTime? LastLogin { get; set; }
        // public string Role { get; set; }

        public string Role { get; set; }
    }
}
