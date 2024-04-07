using Stripe;
using Stripe.Checkout;
using TutoringPlatform.PrivateInterfaces;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Services
{
    public class PaymentService : IPayment
    {
        public PaymentService()
        {
            StripeConfiguration.ApiKey = "sk_test_51Op8jpJo2w8g3pvL3CX9yWZ3DFiMHtOmckDTCSdQSghad2E1rTbnSclEDrGyal7C1OxBXi4RY6AyXMkWYZNqmweD00rc0aCjaE";
        }

        public string CreateCheckoutSession(List<Order> cartItems)
        {
            if (cartItems == null) return null!;

            var lineItems = new List<SessionLineItemOptions>();

            cartItems.ForEach(ci => lineItems.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = ci.Price * 100,
                    Currency = "gbp",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = ci.Name
                    }                   
                },
                Quantity = ci.Quantity
            }));

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = ["card"],
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "https://localhost:7113/order-success",
                CancelUrl = "https://localhost:7113"
            };

            var service = new SessionService();
            Session session = service.Create(options);
            return session.Url;
        }
    }
}
