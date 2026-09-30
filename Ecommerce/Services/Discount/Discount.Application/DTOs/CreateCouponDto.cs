namespace Discount.Application.DTOs
{
    public record CreateCouponDto(
        string ProductName,
        string Description,
        decimal Amount);
}