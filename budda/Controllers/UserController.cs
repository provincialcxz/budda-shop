using budda.BLL;
using budda.Core.Models;
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
        private readonly UserBLL _userLogic = new UserBLL();

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userLogic.Get(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            _userLogic.Post(user);

            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User updatedUser)
        {
            var existingUser = _userLogic.Get(id);
            if (existingUser == null)
                return NotFound();

            existingUser.Name = updatedUser.Name;

            _userLogic.Put(existingUser);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userLogic.Get(id);
            if (user == null)
                return NotFound();

            _userLogic.Delete(id);

            return NoContent();
        }
    }
}