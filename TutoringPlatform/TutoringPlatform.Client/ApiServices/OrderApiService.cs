using System.Net.Http.Json;
using TutoringPlatform.Shared.Interfaces;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Client.ApiServices
{
    public class OrderApiService : IOrderService
    {
        private readonly HttpClient httpClient;

        public OrderApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            var newOrder = await httpClient.PostAsJsonAsync("api/Order/Add-Order", order);
            var response = await newOrder.Content.ReadFromJsonAsync<Order>();
            return response!;
        }

        public Task<IEnumerable<Order>> GetUserOrderHistoryAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
