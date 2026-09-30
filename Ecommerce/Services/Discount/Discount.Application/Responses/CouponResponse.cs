namespace Discount.Application.Responses
{
    public record CouponResponse(
        int Id,
        string ProductName,
        string Description,
        decimal Amount);
}