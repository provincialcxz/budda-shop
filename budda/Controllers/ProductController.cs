using budda.BLL;
using budda.DAL;
using budda.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace budda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductBLL _productLogic = new ProductBLL();
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> GetProduct()
        {
            return _productLogic.GetProduct();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productLogic.Get(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _productLogic.Post(product);

            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product updatedProduct)
        {
            var existingProduct = _productLogic.Get(id);
            if (existingProduct == null)
                return NotFound();

            existingProduct.ProductName = updatedProduct.ProductName;

            _productLogic.Put(existingProduct);

            return NoContent();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productLogic.Get(id);
            if (product == null)
                return NotFound();

            _productLogic.Delete(id);

            return NoContent();
        }
    }
}
