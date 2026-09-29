using Catalog.Application.Commands;
using Catalog.Application.DTOs;
using Catalog.Application.Queries;
using Catalog.Core.Specifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts(
            [FromQuery] CatalogSpecParams specParams)
        {
            var result = await _mediator.Send(
                new GetAllProductsQuery(specParams));

            return Ok(result);
        }

        [HttpGet("brands")]
        public async Task<IActionResult> GetBrands()
        {
            var result = await _mediator.Send(new GetAllBrandsQuery());

            return Ok(result);
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetTypes()
        {
            var result = await _mediator.Send(new GetAllTypesQuery());

            return Ok(result);
        }

        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(id));

            if(result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet("products/name/{name}")]
        public async Task<IActionResult> GetProductsByName(string name)
        {
            var result = await _mediator.Send(new GetProductByNameQuery(name));

            return Ok(result);
        }

        [HttpGet("products/brand/{name}")]
        public async Task<IActionResult> GetProductsByBrand(string name)
        {
            var result = await _mediator.Send(new GetProductByBrandQuery(name));

            return Ok(result);
        }

        [HttpPost("products")]
        public async Task<IActionResult> CreateProduct(
    [FromBody] CreateProductDto product)
        {
            var command = new CreateProductCommand
            {
                Name = product.Name,
                Summary = product.Summary,
                Description = product.Description,
                ImageFile = product.ImageFile,
                BrandId = product.BrandId,
                TypeId = product.TypeId,
                Price = decimal.Parse(product.PriceId)
            };

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("products/{id}")]
        public async Task<IActionResult> UpdateProduct(string id, [FromBody] UpdateProductDto product)
        {
            var result = await _mediator.Send(new UpdateProductCommand(id, product));

            if(result == null) return NotFound();

            return Ok(result);
        }

        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var result = await _mediator.Send(
                new DeleteProductByIdCommand(id));

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}