using MagazinAlimentar.Models.Base;

namespace MagazinAlimentar.Models
{
    public class UserDates : BaseEntity
    {
        public DateTime? DateJoined { get; set; }
        public DateTime? DateLeft { get; set;}

        public User? User { get; set; }
        public Guid? UserId { get; set; }
    }
}
