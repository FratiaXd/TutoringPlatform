using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutoringPlatform.Shared.Models;
using TutoringPlatform.Shared.Responses;

namespace TutoringPlatform.Shared.Interfaces
{
    public interface ICartService
    {
        public bool OnClient();
        public Action? CartAction { get; set; }
        public int CartCount { get; set; }
        Task GetCartCount();
        Task<ServiceResponse> AddToCart(Course course, int updQuantity = 1);
        Task<List<Order>> MyOrders(string userId);
        Task<ServiceResponse> DeleteCart(Order cart);
        Task<ServiceResponse> DeleteAllCartOrders();
        bool IsCartLoaderVisible { get; set; }
        Task<string> Checkout(List<Order> cartItems);
    }
}
