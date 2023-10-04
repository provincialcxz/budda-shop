using budda.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace budda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private List<Order> orders = new List<Order>
        {
            new Order { Id = 1, CustomerName = "Customer1", OrderId = 1 },
            new Order { Id = 2, CustomerName = "Customer2", OrderId = 2 },
            new Order { Id = 3, CustomerName = "Customer3", OrderId = 3 }
        };

        // GET: api/Orders
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return orders;
        }

        // GET api/Orders/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var order = orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        // POST api/Orders
        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            order.Id = orders.Max(o => o.Id) + 1;
            orders.Add(order);

            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }

        // PUT api/Orders/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Order updatedOrder)
        {
            var order = orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound();

            order.CustomerName = updatedOrder.CustomerName;

            return NoContent();
        }

        // DELETE api/Orders/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound();

            orders.Remove(order);

            return NoContent();
        }
    }
}