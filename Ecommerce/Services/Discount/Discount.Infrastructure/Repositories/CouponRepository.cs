using Discount.Core.Entities;
using Discount.Core.Repositories;
using Discount.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Discount.Infrastructure.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly DiscountContext _context;

        public CouponRepository(DiscountContext context)
        {
            _context = context;
        }

        public async Task<Coupon?> GetCoupon(string productName)
        {
            return await _context.Coupons
                .FirstOrDefaultAsync(x => x.ProductName == productName);
        }

        public async Task<Coupon> CreateCoupon(Coupon coupon)
        {
            _context.Coupons.Add(coupon);
            await _context.SaveChangesAsync();

            return coupon;
        }

        public async Task<bool> UpdateCoupon(Coupon coupon)
        {
            var existingCoupon = await _context.Coupons
                .FirstOrDefaultAsync(x => x.Id == coupon.Id);

            if (existingCoupon == null)
                return false;

            existingCoupon.ProductName = coupon.ProductName;
            existingCoupon.Description = coupon.Description;
            existingCoupon.Amount = coupon.Amount;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCoupon(string productName)
        {
            var coupon = await GetCoupon(productName);

            if (coupon == null)
                return false;

            _context.Coupons.Remove(coupon);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}