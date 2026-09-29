namespace Discount.Application.DTOs
{
    public record CouponDto(
        int Id,
        string ProductName,
        string Description,
        decimal Amount);
}