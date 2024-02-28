using TutoringPlatform.Shared.Models;
using TutoringPlatform.Shared.Responses;

namespace TutoringPlatform.Client.PrivateInterfaces
{
    public interface ICart
    {
        public Action? CartAction { get; set; }
        public int CartCount { get; set; }
        Task GetCartCount();
        Task<ServiceResponse> AddToCart(Course course, int updQuantity = 1);
        Task<List<Order>> MyOrders(string userId);
        Task<ServiceResponse> DeleteCart(Order cart);
        bool IsCartLoaderVisible { get; set; }
    }
}
