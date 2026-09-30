using Discount.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Discount.Infrastructure.Data
{
    public class DiscountContext : DbContext
    {
        public DiscountContext(DbContextOptions<DiscountContext> options)
            : base(options)
        {
        }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>()
                .Property(x => x.Amount)
                .HasPrecision(18, 2);
        }
    }
}