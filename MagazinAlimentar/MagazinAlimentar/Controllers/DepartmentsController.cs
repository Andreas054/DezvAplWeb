using MagazinAlimentar.Data;
using MagazinAlimentar.DTOs;
using MagazinAlimentar.Models.One_to_Many;
using MagazinAlimentar.Services.DepartmentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagazinAlimentar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private IDepartmentService _departmentsService;

        public DepartmentsController(IDepartmentService departmentsService)
        {
            _departmentsService = departmentsService;
        }

        [HttpGet("getProducts")]
        public async Task<IActionResult> GetProducts(Guid idDepartment)
        {
            return Ok(_departmentsService.GetProductsForDepartment(idDepartment));
        }

        [HttpGet("getDepartments")]
        public async Task<IActionResult> GetDepartments()
        {
            return Ok(await _departmentsService.GetAllDepartments());
        }

        [HttpPost("createDepartment")]
        public async Task<IActionResult> Create(DepartmentDTO departmentDTO)
        {
            var newDepartment = new Department
            {
                Id = Guid.NewGuid(),
                Name = departmentDTO.Name,
                AgeRestriction = departmentDTO.AgeRestriction
            };

            await _departmentsService.Create(newDepartment);
            return Ok(newDepartment);
        }

        [HttpPut("updateDepartment")]
        public async Task<IActionResult> Update(Guid id, DepartmentDTO departmentDTO)
        {
            var departmentUpdate = _departmentsService.GetById(id);
            if (departmentUpdate == null)
            {
                return BadRequest("department not found");
            }

            departmentUpdate.Name = departmentDTO.Name;
            departmentUpdate.AgeRestriction = departmentDTO.AgeRestriction;
            _departmentsService.Update(departmentUpdate);
            return Ok(departmentUpdate);
        }

        [HttpDelete("deleteDepartment")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var departmentDelete = _departmentsService.GetById(id);
            if (departmentDelete == null)
            {
                return BadRequest("department not found");
            }

            _departmentsService.Delete(departmentDelete);
            return Ok(id);
        }


        [HttpPost("addProducts")]
        public async Task<IActionResult> AddProducts(Guid idDepartment, ProductDTO productDTO)
        {
            var departmentUpdate = _departmentsService.GetById(idDepartment);
            if (departmentUpdate == null) {
                return BadRequest("department does not exist");
            }

            var newProduct = new Product
            {
                Id = Guid.NewGuid(),
                Name = productDTO.Name
            };

            await _departmentsService.CreateProduct(newProduct);
            departmentUpdate.Products.Add(newProduct);

            await _departmentsService.Update(departmentUpdate);

            return Ok(departmentUpdate);
        }

        /*[HttpPost("department/{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] DepartmentDTO departmentDTO)
        {
            Department departmentById = _departmentsService.GetById(id);
            if (departmentById == null)
            {
                return BadRequest("Object does not exist");
            }

            departmentById.Name = departmentDTO.Name;

            _magazinContext.Update(departmentById);
            await _magazinContext.SaveChangesAsync();
            return Ok(departmentById);
        }*/
    }
}
