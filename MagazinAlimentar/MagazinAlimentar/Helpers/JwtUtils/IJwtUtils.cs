using MagazinAlimentar.Models;

namespace MagazinAlimentar.Helpers.JwtUtils
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public Guid ValidateJwtToken(string token);
    }
}
