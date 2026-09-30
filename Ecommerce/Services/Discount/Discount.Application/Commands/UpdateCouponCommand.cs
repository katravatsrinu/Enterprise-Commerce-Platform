using Discount.Application.DTOs;
using MediatR;

namespace Discount.Application.Commands
{
    public record UpdateCouponCommand(
        UpdateCouponDto Coupon) : IRequest<bool>;
}