using MediatR;
using Ordering.Application.Commands;
using Ordering.Core.Repositories;

namespace Ordering.Application.Handlers
{
    public class DeleteOrderHandler
        : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(
            DeleteOrderCommand request,
            CancellationToken cancellationToken)
        {
            return await _orderRepository.DeleteOrder(request.Id);
        }
    }
}