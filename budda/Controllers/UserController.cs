using Microsoft.AspNetCore.Mvc;
using System;
using budda.BLL;
using budda.Core.Models;
using Microsoft.AspNetCore.Authorization;

namespace budda.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly UserBLL userBLL;

        public UserController(UserBLL userBLL)
        {
            userBLL = user_BLL;
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = userBLL.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("email/{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            var user = userBLL.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] User user)
        {
            // можно сделать проверку перед регистрацией
            userBLL.RegisterUser(user);
            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public IActionResult LoginUser([FromBody] User user)
        {
            var loggedInUser = userBLL.LoginUser(user.mail, user.Password);
            if (loggedInUser == null)
            {
                return BadRequest("Login failed");
            }
            return Ok("Login successful");
        }

        [Authorize]
        [HttpPut("profile")]
        public IActionResult UpdateProfile([FromBody] User user)
        {
            userBLL.UpdateProfile(user);
            return Ok("Profile updated successfully");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            userBLL.DeleteUser(id);
            return Ok("User deleted successfully");
        }
    }
}