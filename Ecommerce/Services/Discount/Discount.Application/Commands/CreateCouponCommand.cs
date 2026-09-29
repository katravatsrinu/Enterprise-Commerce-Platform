using Discount.Application.DTOs;
using Discount.Application.Responses;
using Discount.Core.Entities;
using MediatR;

namespace Discount.Application.Commands
{
    public record CreateCouponCommand(CreateCouponDto Coupon) : IRequest<CouponResponse>;
}