using MediatR;
using Ordering.Application.DTOs;

namespace Ordering.Application.Commands
{
    public record CheckoutOrderCommand(
        string UserName,
        decimal TotalPrice
    ) : IRequest<OrderingDto>;
}