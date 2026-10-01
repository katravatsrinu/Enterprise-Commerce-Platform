using MediatR;
using Ordering.Application.DTOs;

namespace Ordering.Application.Queries
{
    public record GetOrderList(string UserName)
        : IRequest<IList<OrderingDto>>;
}