using budda.BLL;
using budda.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace budda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserBLL _userLogic = new UserBLL();

        // GET api/<UserController>/5
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

        // DELETE api/<UserController>/5
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
