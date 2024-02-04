using MagazinAlimentar.Data;
using MagazinAlimentar.Models.One_to_Many;
using MagazinAlimentar.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace MagazinAlimentar.Repositories.DepartmentRepository
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(MagazinContext magazinContext) : base(magazinContext) { }

        public List<Department> GetAllWithInclude()
        {
            var result = _table.Include(dep => dep.Products).ThenInclude(prod => prod.Department).ToList();
            return result;
        }

        public List<dynamic> GetAllWithJoin()
        {
            var result = _magazinContext.Departments.Join(_magazinContext.Products, dep => dep.Id, prod => prod.DepartmentId,
                (dep, prod) => new { dep, prod }).Select(ob => ob.dep);

            return (List<dynamic>)result;
        }

        public List<Product> GetProductsForDepartment(Guid idDepartment)
        {
            return _magazinContext.Products.Where(dep => dep.DepartmentId == idDepartment).ToList();
        }
    }
}
