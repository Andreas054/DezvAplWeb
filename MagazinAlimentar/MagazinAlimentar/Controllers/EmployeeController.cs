using MagazinAlimentar.DTOs;
using MagazinAlimentar.Models.Many_to_Many;
using MagazinAlimentar.Services.EmployeeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagazinAlimentar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("getEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(await _employeeService.GetAllEmployees());
        }

        [HttpPost("createEmployee")]
        public async Task<IActionResult> Create(EmployeeDTO employeeDTO)
        {
            var newEmployee = new Employee
            {
                Id = Guid.NewGuid(),
                Name = employeeDTO.Name
            };

            await _employeeService.Create(newEmployee);
            return Ok(newEmployee);
        }

        [HttpPut("updateEmployee")]
        public async Task<IActionResult> Update(Guid id, EmployeeDTO employeeDTO)
        {
            var employeeUpdate = _employeeService.GetById(id);
            if (employeeUpdate == null)
            {
                return BadRequest("employee not found");
            }

            employeeUpdate.Name = employeeDTO.Name;
            _employeeService.Update(employeeUpdate);
            return Ok(employeeUpdate);
        }

        [HttpDelete("deleteEmployee")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var employeeDelete = _employeeService.GetById(id);
            if (employeeDelete == null)
            {
                return BadRequest("employee not found");
            }

            _employeeService.Delete(employeeDelete);
            return Ok(id);
        }

        [HttpGet("getAllEmployeeLocations")]
        public async Task<IActionResult> GetAllEmloyeeLocation()
        {
            return Ok(_employeeService.GetLocationEmployeeRelations());
        }
    }
}
