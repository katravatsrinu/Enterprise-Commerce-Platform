using MediatR;
using Ordering.Application.DTOs;

namespace Ordering.Application.Commands
{
    public record UpdateOrderCommand(
        int Id,
        string UserName,
        decimal TotalPrice,
        string Status
    ) : IRequest<OrderingDto>;
}