using Ordering.Core.Entities;

namespace Ordering.Infrastructure.Data
{
    public static class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext context)
        {
            if (!context.Orders.Any())
            {
                context.Orders.AddRange(
                    new Order
                    {
                        UserName = "testuser",
                        TotalPrice = 100,
                        OrderDate = DateTime.UtcNow,
                        Status = OrderStatus.Pending
                    }
                );

                await context.SaveChangesAsync();
            }
        }
    }
}