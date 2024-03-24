using TutoringPlatform.Shared.Interfaces;
using TutoringPlatform.Shared.Models;
using TutoringPlatform.Shared.Responses;

namespace TutoringPlatform.Services
{
    public class CartService : ICartService
    {
        Action? ICartService.CartAction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int ICartService.CartCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        bool ICartService.IsCartLoaderVisible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool OnClient()
        {
            return false;
        }

        Task<ServiceResponse> ICartService.AddToCart(Course course, int updQuantity)
        {
            return Task.FromResult(new ServiceResponse(false, "Operation not supported server-side"));
        }

        Task<string> ICartService.Checkout(List<Order> cartItems)
        {
            return null!;
        }

        Task<ServiceResponse> ICartService.DeleteAllCartOrders()
        {
            return Task.FromResult(new ServiceResponse(false, "Operation not supported server-side"));
        }

        Task<ServiceResponse> ICartService.DeleteCart(Order cart)
        {
            return Task.FromResult(new ServiceResponse(false, "Operation not supported server-side"));
        }

        Task ICartService.GetCartCount()
        {
            return null!;
        }

        Task<List<Order>> ICartService.MyOrders(string userId)
        {
            return null!;
        }
    }
}
