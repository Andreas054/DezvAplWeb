using MagazinAlimentar.Data;
using MagazinAlimentar.DTOs;
using MagazinAlimentar.Helpers.Attributes;
using MagazinAlimentar.Models;
using MagazinAlimentar.Models.Enums;
using MagazinAlimentar.Models.One_to_Many;
using MagazinAlimentar.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using BCryptNet = BCrypt.Net.BCrypt;

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

        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser(UserRequestDTO user)
        {
            var userToCreate = new User
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = Role.User,
                PasswordHash = BCryptNet.HashPassword(user.Password)
            };

            await _userService.Create(userToCreate);
            return Ok();
        }

        [HttpPost("createAdmin")]
        public async Task<IActionResult> CreateAdmin(UserRequestDTO user)
        {
            var userToCreate = new User
            {
                UserName = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = Role.Admin,
                PasswordHash = BCryptNet.HashPassword(user.Password)
            };

            await _userService.Create(userToCreate);
            return Ok();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(UserRequestDTO user)
        {
            var response = _userService.Authenticate(user);
            if (response == null)
            {
                return BadRequest("Username/password invalid");
            }
            return Ok();
        }

        //[Authorization(Role.Admin)]
        [HttpGet("admin")]
        public async Task<IActionResult> GetAllAdmin()
        {
            return Ok(await _userService.GetAllUsers());
        }

        //[Authorization(Role.User)]
        [HttpGet("user")]
        public IActionResult GetAllUser()
        {;
            return Ok("User");
        }

        [HttpPut("updateUser")]
        public async Task<IActionResult> Update(Guid id, UserSimpleDTO userSimpleDTO)
        {
            var userUpdate = _userService.GetById(id);
            if (userUpdate == null)
            {
                return BadRequest("user not found");
            }

            userUpdate.FirstName = userSimpleDTO.FirstName;
            userUpdate.LastName = userSimpleDTO.LastName;
            _userService.Update(userUpdate);
            return Ok(userUpdate);
        }

        [HttpDelete("deleteUser")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var userDelete = _userService.GetById(id);
            if (userDelete == null)
            {
                return BadRequest("user not found");
            }

            _userService.Delete(userDelete);
            return Ok(id);
        }
    }
}
