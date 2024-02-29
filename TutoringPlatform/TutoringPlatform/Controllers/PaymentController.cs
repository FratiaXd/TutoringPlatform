using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TutoringPlatform.PrivateInterfaces;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPayment paymentService;

        public PaymentController(IPayment paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpPost("Checkout")]
        public ActionResult CreateCheckoutSession(List<Order> cartItems)
        {
            var url = paymentService.CreateCheckoutSession(cartItems);
            return Ok(url);
        }
    }
}
