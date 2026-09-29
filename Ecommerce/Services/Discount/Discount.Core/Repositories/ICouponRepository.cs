using Discount.Core.Entities;

namespace Discount.Core.Repositories
{
    public interface ICouponRepository
    {
        Task<Coupon?> GetCoupon(string productName);
        Task<Coupon> CreateCoupon(Coupon coupon);
        Task<bool> UpdateCoupon(Coupon coupon);
        Task<bool> DeleteCoupon(string productName);
    }
}