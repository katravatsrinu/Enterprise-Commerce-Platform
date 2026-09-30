using Discount.Application.Commands;
using Discount.Core.Repositories;
using MediatR;

namespace Discount.Application.Handlers
{
    public class DeleteCouponHandler
        : IRequestHandler<DeleteCouponCommand, bool>
    {
        private readonly ICouponRepository _couponRepository;

        public DeleteCouponHandler(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        public async Task<bool> Handle(
            DeleteCouponCommand request,
            CancellationToken cancellationToken)
        {
            return await _couponRepository
                .DeleteCoupon(request.ProductName);
        }
    }
}