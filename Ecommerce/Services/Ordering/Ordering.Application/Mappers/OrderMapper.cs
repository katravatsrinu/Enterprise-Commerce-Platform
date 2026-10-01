using Ordering.Application.DTOs;
using Ordering.Core.Entities;

namespace Ordering.Application.Mappers
{
    public static class OrderMapper
    {
        public static OrderingDto ToDto(this Order order)
        {
            if (order == null)
                return null;

            return new OrderingDto
            {
                Id = order.Id,
                UserName = order.UserName,
                TotalPrice = order.TotalPrice,
                OrderDate = order.OrderDate,
                Status = order.Status.ToString()
            };
        }

        public static IList<OrderingDto> ToDtoList(
            this IEnumerable<Order> orders)
        {
            return orders
                .Select(x => x.ToDto())
                .ToList();
        }
    }
}