using Ordering.Core.Entities;
using Ordering.Infrastructure.Constants;
using System.Text.Json;

namespace Ordering.Application.Extensions
{
    public static class OutboxMessageFactory
    {
        public static OutboxMessage CreateOrderCreated(Order order)
        {
            return new OutboxMessage
            {
                Type = OutboxMessageTypes.OrderCreated,
                Content = JsonSerializer.Serialize(order),
                CreatedAt = DateTime.UtcNow
            };
        }

        public static OutboxMessage CreateOrderUpdated(Order order)
        {
            return new OutboxMessage
            {
                Type = OutboxMessageTypes.OrderUpdated,
                Content = JsonSerializer.Serialize(order),
                CreatedAt = DateTime.UtcNow
            };
        }

        public static OutboxMessage CreateOrderDeleted(int orderId)
        {
            return new OutboxMessage
            {
                Type = OutboxMessageTypes.OrderDeleted,
                Content = JsonSerializer.Serialize(new { OrderId = orderId }),
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}