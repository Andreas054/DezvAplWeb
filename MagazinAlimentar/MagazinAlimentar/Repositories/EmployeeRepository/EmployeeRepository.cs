using MagazinAlimentar.Data;
using MagazinAlimentar.Models.Many_to_Many;
using MagazinAlimentar.Repositories.GenericRepository;

namespace MagazinAlimentar.Repositories.EmployeeRepository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(MagazinContext magazinContext) : base(magazinContext) { }
    }
}
