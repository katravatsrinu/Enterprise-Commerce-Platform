using Discount.Application.Commands;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using MediatR;

namespace Discount.Application.Handlers
{
    public class UpdateCouponHandler
        : IRequestHandler<UpdateCouponCommand, bool>
    {
        private readonly ICouponRepository _couponRepository;

        public UpdateCouponHandler(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        public async Task<bool> Handle(
            UpdateCouponCommand request,
            CancellationToken cancellationToken)
        {
            var existingCoupon = await _couponRepository
                .GetCoupon(request.Coupon.ProductName);

            if (existingCoupon == null)
                return false;

            var coupon = new Coupon
            {
                Id = existingCoupon.Id,
                ProductName = request.Coupon.ProductName,
                Description = request.Coupon.Description,
                Amount = request.Coupon.Amount
            };

            return await _couponRepository.UpdateCoupon(coupon);
        }
    }
}