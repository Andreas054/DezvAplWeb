using DAW_Lab3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DAW_Lab3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly Lab3Context _lab3Context;
        public DatabaseController(Lab3Context lab3Context) { 
            _lab3Context = lab3Context;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            return Ok(await _lab3Context.Students.ToListAsync());
        }
    }
}
