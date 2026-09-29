using MediatR;

namespace Discount.Application.Commands
{
    public record DeleteCouponCommand(
        string ProductName) : IRequest<bool>;
}