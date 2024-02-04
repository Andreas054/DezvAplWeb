using AutoMapper;
using MagazinAlimentar.Helpers.JwtUtils;
using MagazinAlimentar.Models.One_to_Many;
using MagazinAlimentar.Repositories.DepartmentRepository;
using MagazinAlimentar.Repositories.ProductRepository;

namespace MagazinAlimentar.Services.DepartmentService
{
    public class DepartmentService : IDepartmentService
    {
        public IDepartmentRepository _departmentRepository;
        public IProductRepository _productRepository;
        public IMapper _mapper;
        public IJwtUtils _jwtUtils;

        public DepartmentService(IDepartmentRepository departmentRepository, IProductRepository productRepository, IMapper mapper, IJwtUtils jwtUtils)
        {
            _departmentRepository = departmentRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await _departmentRepository.GetAllAsync();
        }
        public Department GetById(Guid id)
        {
            return _departmentRepository.FindById(id);
        }
        public async Task Create(Department newDepartment)
        {
            await _departmentRepository.CreateAsync(newDepartment);
            await _departmentRepository.SaveAsync();
        }

        public async Task Update(Department newDepartment)
        {
            _departmentRepository.Update(newDepartment);
            await _departmentRepository.SaveAsync();
        }

        public async Task Delete(Department departmentDelete)
        {
            _departmentRepository.Delete(departmentDelete);
            await _departmentRepository.SaveAsync();
        }
        
        public async Task CreateProduct(Product newProduct)
        {
            await _productRepository.CreateAsync(newProduct);
            await _productRepository.SaveAsync();
        }

        public List<Product> GetProductsForDepartment(Guid idDepartment)
        {
            return _departmentRepository.GetProductsForDepartment(idDepartment);
        }
    }
}
