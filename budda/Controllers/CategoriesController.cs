using budda.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace budda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private List<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Category1" },
            new Category { Id = 2, Name = "Category2" },
            new Category { Id = 3, Name = "Category3" }
        };

        // GET: api/Categories
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return categories;
        }

        // GET api/Categories/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        // POST api/Categories
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            category.Id = categories.Max(c => c.Id) + 1;
            categories.Add(category);

            return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
        }

        // PUT api/Categories/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category updatedCategory)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return NotFound();

            category.Name = updatedCategory.Name;

            return NoContent();
        }

        // DELETE api/Categories/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                return NotFound();

            categories.Remove(category);

            return NoContent();
        }
    }
}