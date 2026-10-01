using MediatR;
using Ordering.Application.DTOs;
using Ordering.Application.Queries;
using Ordering.Core.Repositories;

namespace Ordering.Application.Handlers
{
    public class GetOrderListHandler
        : IRequestHandler<GetOrderList, IList<OrderingDto>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderListHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IList<OrderingDto>> Handle(
            GetOrderList request,
            CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrders(request.UserName);

            return orders.Select(x => new OrderingDto
            {
                Id = x.Id,
                UserName = x.UserName,
                TotalPrice = x.TotalPrice,
                OrderDate = x.OrderDate,
                Status = x.Status.ToString()
            }).ToList();
        }
    }
}