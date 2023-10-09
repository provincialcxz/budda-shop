using Microsoft.AspNetCore.Mvc;
using budda.BLL;
using budda.Core.Models;
using budda.Models;

namespace budda.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserBLL _userBLL = new UserBLL();

        public UserController(UserBLL user_BLL)
        {
            _userBLL = user_BLL;
        }

        [HttpGet("{userId}/cart")]
        public IActionResult GetUserCart(int userId)
        {
            var cart = _userBLL.GetUserCart(userId);
            return Ok(cart);
        }

        [HttpPost("{userId}/cart/add")]
        public IActionResult AddProductToCart(int userId, [FromBody] Product product)
        {
            var productId = product.Id;
            _userBLL.AddProductToCart(userId, productId);
            return Ok("Product added to cart successfully");
        }

        [HttpPut("{userId}/cart")]
        public IActionResult UpdateUserCart(int userId, [FromBody] Cart cart)
        {
            _userBLL.UpdateUserCart(userId, cart);
            return Ok("User cart updated successfully");
        }

        [HttpDelete("{userId}/cart/{productId}")]
        public IActionResult RemoveProductFromCart(int userId, int productId)
        {
            _userBLL.RemoveProductFromCart(userId, productId);
            return Ok("Product removed from cart successfully");
        }
    }
}