using MagazinAlimentar.Models.Many_to_Many;

namespace MagazinAlimentar.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployees();
        Employee GetById(Guid id);
        Task Create(Employee newEmployee);
        Task Update(Employee newEmployee);
        Task Delete(Employee employeeDelete);
    }
}
