using MediatR;
using Ordering.Application.Commands;
using Ordering.Application.DTOs;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;

namespace Ordering.Application.Handlers
{
    public class CheckoutOrderHandler
        : IRequestHandler<CheckoutOrderCommand, OrderingDto>
    {
        private readonly IOrderRepository _orderRepository;

        public CheckoutOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderingDto> Handle(
            CheckoutOrderCommand request,
            CancellationToken cancellationToken)
        {
            var order = new Order
            {
                UserName = request.UserName,
                TotalPrice = request.TotalPrice,
                OrderDate = DateTime.UtcNow,
                Status = OrderStatus.Pending
            };

            var createdOrder = await _orderRepository.CreateOrder(order);

            return new OrderingDto
            {
                Id = createdOrder.Id,
                UserName = createdOrder.UserName,
                TotalPrice = createdOrder.TotalPrice,
                OrderDate = createdOrder.OrderDate,
                Status = createdOrder.Status.ToString()
            };
        }
    }
}