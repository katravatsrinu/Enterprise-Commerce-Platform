using MediatR;
using Ordering.Application.Commands;
using Ordering.Application.DTOs;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;

namespace Ordering.Application.Handlers
{
    public class UpdateOrderHandler
        : IRequestHandler<UpdateOrderCommand, OrderingDto>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderingDto> Handle(
            UpdateOrderCommand request,
            CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderById(request.Id);

            if (order == null)
                throw new ApplicationException("Order not found");

            order.UserName = request.UserName;
            order.TotalPrice = request.TotalPrice;

            if (Enum.TryParse<OrderStatus>(
                request.Status,
                true,
                out var status))
            {
                order.Status = status;
            }

            await _orderRepository.UpdateOrder(order);

            return new OrderingDto
            {
                Id = order.Id,
                UserName = order.UserName,
                TotalPrice = order.TotalPrice,
                OrderDate = order.OrderDate,
                Status = order.Status.ToString()
            };
        }
    }
}