using Discount.Application.Commands;
using Discount.Application.Responses;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using MediatR;

namespace Discount.Application.Handlers
{
    public class CreateCouponHandler
        : IRequestHandler<CreateCouponCommand, CouponResponse>
    {
        private readonly ICouponRepository _couponRepository;

        public CreateCouponHandler(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        public async Task<CouponResponse> Handle(
            CreateCouponCommand request,
            CancellationToken cancellationToken)
        {
            var existingCoupon = await _couponRepository
                .GetCoupon(request.Coupon.ProductName);

            if (existingCoupon != null)
            {
                throw new ApplicationException(
                    "Coupon already exists for this product.");
            }

            var coupon = new Coupon
            {
                ProductName = request.Coupon.ProductName,
                Description = request.Coupon.Description,
                Amount = request.Coupon.Amount
            };

            var createdCoupon = await _couponRepository
                .CreateCoupon(coupon);

            return new CouponResponse(
                createdCoupon.Id,
                createdCoupon.ProductName,
                createdCoupon.Description,
                createdCoupon.Amount);
        }
    }
}