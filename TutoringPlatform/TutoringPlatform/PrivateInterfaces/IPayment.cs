using Stripe.Checkout;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.PrivateInterfaces
{
    public interface IPayment
    {
        string CreateCheckoutSession(List<Order> cartItems);

    }
}
