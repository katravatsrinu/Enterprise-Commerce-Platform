using Discount.Application.Commands;
using Discount.Application.DTOs;
using Discount.Application.Handlers;
using Discount.Application.Queries;
using Discount.Application.Responses;
using Discount.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Channels;

namespace Discount.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiscountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{productName}")]
        public async Task<ActionResult<CouponResponse>> GetDiscount(
            string productName)
        {
            var coupon = await _mediator.Send(
                new GetCouponQuery(productName));

            if (coupon == null)
                return NotFound();

            return Ok(coupon);
        }

        [HttpPost]
        public async Task<ActionResult<CouponResponse>> CreateDiscount(
            CreateCouponDto coupon)
        {
            try
            {
                var result = await _mediator.Send(
                    new CreateCouponCommand(coupon));

                return Ok(result);
            }
            catch (ApplicationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDiscount(
            UpdateCouponDto coupon)
        {
            var result = await _mediator.Send(
                new UpdateCouponCommand(coupon));

            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{productName}")]
        public async Task<ActionResult> DeleteDiscount(
            string productName)
        {
            var result = await _mediator.Send(
                new DeleteCouponCommand(productName));

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
