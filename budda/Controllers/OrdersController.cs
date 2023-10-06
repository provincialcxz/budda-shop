using budda.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/order")]
public class OrderController : ControllerBase
{
    private readonly OrderBLL _orderBLL;

    public OrderController(OrderBLL orderBLL)
    {
        _orderBLL = orderBLL;
    }

    [HttpPost("create")]
    public IActionResult CreateOrder([FromBody] Order order)
    {
        var createdOrder = _orderBLL.CreateOrder(order);
        return Ok(createdOrder);
    }

    [HttpGet("{id}")]
    public IActionResult GetOrder(int id)
    {
        var order = _orderBLL.GetOrder(id);
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    [Authorize]
    [HttpGet("user")]
    public IActionResult GetUserOrders()
    {
        var userId = HttpContext.User.Identity.Name;

        var userOrders = _orderBLL.GetUserOrders(userId);
        return Ok(userOrders);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateOrder(int id, [FromBody] string newStatus)
    {
        _orderBLL.UpdateOrder(id, newStatus);
        return Ok("Order status updated successfully");
    }
}