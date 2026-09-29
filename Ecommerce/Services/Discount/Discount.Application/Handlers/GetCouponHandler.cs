using Discount.Application.Queries;
using Discount.Application.Responses;
using Discount.Core.Repositories;
using MediatR;

namespace Discount.Application.Handlers
{
    public class GetCouponHandler
        : IRequestHandler<GetCouponQuery, CouponResponse?>
    {
        private readonly ICouponRepository _couponRepository;

        public GetCouponHandler(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        public async Task<CouponResponse?> Handle(
            GetCouponQuery request,
            CancellationToken cancellationToken)
        {
            var coupon = await _couponRepository
                .GetCoupon(request.ProductName);

            if (coupon == null)
                return null;

            return new CouponResponse(
                coupon.Id,
                coupon.ProductName,
                coupon.Description,
                coupon.Amount);
        }
    }
}