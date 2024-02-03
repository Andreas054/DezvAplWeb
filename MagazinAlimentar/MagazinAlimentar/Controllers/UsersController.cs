using MagazinAlimentar.Data;
using MagazinAlimentar.DTOs;
using MagazinAlimentar.Models;
using MagazinAlimentar.Models.One_to_Many;
using MagazinAlimentar.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace MagazinAlimentar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        /*private readonly MagazinContext _magazinContext;
        public UsersController(MagazinContext magazinContext) {
            _magazinContext = magazinContext;
        }*/

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUserByName([FromHeader] string name)
        {
            return Ok(_userService.GetUserByName(name));
        }

        /*[HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _magazinContext.Users.ToListAsync());
        }*/

        [HttpPost]
        public async Task<IActionResult> Create(UserDTO userDTO)
        {
            return Ok(_userService.Create(userDTO));
        }
    }
}
