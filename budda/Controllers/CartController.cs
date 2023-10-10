using Microsoft.AspNetCore.Mvc;
using budda.BLL;
using budda.Core.Models;

namespace budda.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartBLL _cartBLL;

        public CartController(CartBLL cartBLL)
        {
            _cartBLL = cartBLL;
        }

        // GET: api/cart
        [HttpGet]
        public IActionResult GetCarts()
        {
            var carts = _cartBLL.GetCart();
            return Ok(carts);
        }

        // POST: api/cart
        [HttpPost]
        public IActionResult PostCart([FromBody] Cart cart)
        {
            _cartBLL.Post(cart);
            return Ok("Cart created successfully");
        }

        // PUT: api/cart/{id}
        [HttpPut("{id}")]
        public IActionResult PutCart(int id, [FromBody] Cart cart)
        {
            cart.ProductId = id;
            _cartBLL.Put(cart);
            return Ok("Cart updated successfully");
        }

        // DELETE: api/cart/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCart(int id)
        {
            _cartBLL.Delete(id);
            return Ok("Cart deleted successfully");
        }
    }
}