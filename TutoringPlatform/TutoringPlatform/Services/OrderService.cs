using Microsoft.EntityFrameworkCore;
using TutoringPlatform.Data;
using TutoringPlatform.Shared.Interfaces;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDbContextFactory<TutoringPlatformContext> _contextFactory;

        public OrderService(IDbContextFactory<TutoringPlatformContext> context)
        {
            _contextFactory = context;
        }

        public async Task<Order> AddOrderAsync(Order order)
        {
            if (order == null) return null;

            using var context = _contextFactory.CreateDbContext();
            var newOrder = context.Orders.Add(order).Entity;
            await context.SaveChangesAsync();
            return newOrder;
        }

        public async Task<IEnumerable<Order>> GetUserOrderHistoryAsync(string id)
        {
            if (id == null) return null;
            using var context = _contextFactory.CreateDbContext();

            var existingOrders = await context.Orders
                .Include(o => o.Course)
                .Where(o => o.UserId == id)
                .OrderByDescending(o => o.OrderTime)
                .ToListAsync();

            if (existingOrders == null) return null;

            return existingOrders;
        }
    }
}
