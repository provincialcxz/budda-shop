using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using budda.BLL;
using budda.Models;

namespace budda.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoriesBLL _categoriesBLL;

        public CategoriesController(CategoriesBLL categoriesBLL)
        {
            _categoriesBLL = categoriesBLL;
        }

        // GET: api/categories
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _categoriesBLL.GetCategory();
            return Ok(categories);
        }

        // POST: api/categories
        [HttpPost]
        public IActionResult PostCategory([FromBody] Category category)
        {
            _categoriesBLL.Post(category);
            return Ok("Category created successfully");
        }

        // PUT: api/categories/{id}
        [HttpPut("{id}")]
        public IActionResult PutCategory(int id, [FromBody] Category category)
        {
            category.Id = id;
            _categoriesBLL.Put(category);
            return Ok("Category updated successfully");
        }

        // DELETE: api/categories/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _categoriesBLL.Delete(id);
            return Ok("Category deleted successfully");
        }
    }
}