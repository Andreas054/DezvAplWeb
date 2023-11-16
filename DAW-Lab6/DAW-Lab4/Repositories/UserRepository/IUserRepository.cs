using DAW_Lab4.Models;
using DAW_Lab4.Repositories.GenericRepository;

namespace DAW_Lab4.Repositories.UserRepository
{
    public interface IUserRepository: IGenericRepository<User>
    {
        UserRepository FindByUsername(string username);

        List<User> FindAllActive();
    }
}
