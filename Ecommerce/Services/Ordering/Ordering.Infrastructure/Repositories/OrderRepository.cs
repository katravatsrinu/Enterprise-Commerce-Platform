using Microsoft.EntityFrameworkCore;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;
using Ordering.Infrastructure.Data;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;

        public OrderRepository(OrderContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrders(string userName)
        {
            return await _context.Orders
                .Where(x => x.UserName == userName)
                .ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _context.Orders
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Order> CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<bool> UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteOrder(int id)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
                return false;

            _context.Orders.Remove(order);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Order> CreateOrderWithOutbox(
    Order order,
    OutboxMessage outboxMessage)
        {
            await using var transaction =
                await _context.Database.BeginTransactionAsync();

            try
            {
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                outboxMessage.Content =
                    System.Text.Json.JsonSerializer.Serialize(new
                    {
                        order.Id,
                        order.UserName,
                        order.TotalPrice,
                        order.OrderDate,
                        Status = order.Status.ToString()
                    });

                _context.OutboxMessages.Add(outboxMessage);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return order;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}