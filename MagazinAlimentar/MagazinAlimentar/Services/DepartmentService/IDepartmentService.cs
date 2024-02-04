using MagazinAlimentar.DTOs;
using MagazinAlimentar.Models;
using MagazinAlimentar.Models.One_to_Many;

namespace MagazinAlimentar.Services.DepartmentService
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAllDepartments();
        Department GetById(Guid id);
        Task Create(Department newDepartment);
        List<Product> GetProductsForDepartment(Guid idDepartment);
        Task Update(Department newDepartment);
        Task Delete(Department departmentDelete);
        Task CreateProduct(Product newProduct);
    }
}
