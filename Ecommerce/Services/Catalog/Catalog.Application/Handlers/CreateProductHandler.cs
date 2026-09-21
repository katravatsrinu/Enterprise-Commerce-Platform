using Catalog.Application.Commands;
using Catalog.Application.Mappers;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductResponse> Handle(
            CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            var dto = request.Product;

            var brand = await _productRepository.GetBrandByIdAsync(dto.BrandId);
            var type = await _productRepository.GetTypesByIdAsync(dto.TypeId);

            var product = new Product
            {
                Name = dto.Name,
                Summary = dto.Summary,
                Description = dto.Description,
                ImageFile = dto.ImageFile,
                Brand = brand,
                Type = type,
                Price = decimal.Parse(dto.PriceId),
                CreatedDate = DateTimeOffset.UtcNow
            };

            var createdProduct = await _productRepository.CreateProduct(product);

            return createdProduct.ToResponse();
        }
    }
}