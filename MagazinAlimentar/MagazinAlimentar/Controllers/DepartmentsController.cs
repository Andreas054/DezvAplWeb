using MagazinAlimentar.Data;
using MagazinAlimentar.DTOs;
using MagazinAlimentar.Models.One_to_Many;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagazinAlimentar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly MagazinContext _magazinContext;
        public DepartmentsController(MagazinContext magazinContext)
        {
            _magazinContext = magazinContext;
        }

        [HttpGet("department")]
        public async Task<IActionResult> GetDepartment()
        {
            return Ok(await _magazinContext.Departments.ToListAsync());
        }

        [HttpPost("department")]
        public async Task<IActionResult> Create(DepartmentDTO departmentDTO)
        {
            var newDepartment = new Department
            {
                Id = Guid.NewGuid(),
                Name = departmentDTO.Name,
                AgeRestriction = departmentDTO.AgeRestriction
            };

            await _magazinContext.AddAsync(newDepartment);
            await _magazinContext.SaveChangesAsync();

            return Ok(newDepartment);
        }

        [HttpPost("department/{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] DepartmentDTO departmentDTO)
        {
            Department departmentById = await _magazinContext.Departments.FirstOrDefaultAsync(x => x.Id == id);
            if (departmentById == null)
            {
                return BadRequest("Object does not exist");
            }

            departmentById.Name = departmentDTO.Name;

            _magazinContext.Update(departmentById);
            await _magazinContext.SaveChangesAsync();
            return Ok(departmentById);
        }
    }
}
