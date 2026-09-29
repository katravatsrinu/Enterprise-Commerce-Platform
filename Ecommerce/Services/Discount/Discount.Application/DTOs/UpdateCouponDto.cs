namespace Discount.Application.DTOs
{
    public record UpdateCouponDto(
        string ProductName,
        string Description,
        decimal Amount);
}