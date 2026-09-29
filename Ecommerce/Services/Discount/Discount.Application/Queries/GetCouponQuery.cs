using Discount.Application.Responses;
using MediatR;

namespace Discount.Application.Queries
{
    public record GetCouponQuery(
        string ProductName) : IRequest<CouponResponse?>;
}