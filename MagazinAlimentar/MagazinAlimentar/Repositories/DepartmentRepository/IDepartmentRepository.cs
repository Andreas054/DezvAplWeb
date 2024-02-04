using MagazinAlimentar.Models.One_to_Many;
using MagazinAlimentar.Repositories.GenericRepository;

namespace MagazinAlimentar.Repositories.DepartmentRepository
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        List<Product> GetProductsForDepartment(Guid idDepartment);
    }
}
