using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TutoringPlatform.Services;
using TutoringPlatform.Shared.Interfaces;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost("Add-Order")]
        public async Task<ActionResult<IEnumerable<Order>>> AddOrderAsync(Order order)
        {
            var newOrder = await orderService.AddOrderAsync(order);
            return Ok(newOrder);
        }
    }
}
