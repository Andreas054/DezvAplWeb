using AutoMapper;
using MagazinAlimentar.Helpers.JwtUtils;
using MagazinAlimentar.Models.Many_to_Many;
using MagazinAlimentar.Repositories.EmployeeRepository;
using MagazinAlimentar.Repositories.LocationRepository;

namespace MagazinAlimentar.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        public IEmployeeRepository _employeeRepository;
        public ILocationRepository _locationRepository;
        public IMapper _mapper;
        public IJwtUtils _jwtUtils;

        public EmployeeService(IEmployeeRepository employeeRepository, ILocationRepository locationRepository, IMapper mapper, IJwtUtils jwtUtils)
        {
            _employeeRepository = employeeRepository;
            _locationRepository = locationRepository;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public Employee GetById(Guid id)
        {
            return _employeeRepository.FindById(id);
        }

        public async Task Create(Employee newEmployee)
        {
            await _employeeRepository.CreateAsync(newEmployee);
            await _employeeRepository.SaveAsync();
        }

        public async Task Update(Employee newEmployee)
        {
            _employeeRepository.Update(newEmployee);
            await _employeeRepository.SaveAsync();
        }

        public async Task Delete(Employee employeeDelete)
        {
            _employeeRepository.Delete(employeeDelete);
            await _employeeRepository.SaveAsync();
        }

        public IQueryable<LocationEmployeeRelation> GetLocationEmployeeRelations()
        {
            return _locationRepository.GetAllLocationEmployeeRelations();
        }
    }
}
