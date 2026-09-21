using Catalog.Application.Commands;
using Catalog.Application.Mappers;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductResponse> Handle(
            UpdateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProduct(request.Id);

            if (product == null)
                return null;

            var dto = request.Product;

            product.Name = dto.Name;
            product.Summary = dto.Summary;
            product.Description = dto.Description;
            product.ImageFile = dto.ImageFile;
            product.Price = decimal.Parse(dto.PriceId);

            product.Brand = await _productRepository.GetBrandByIdAsync(dto.BrandId);
            product.Type = await _productRepository.GetTypesByIdAsync(dto.TypeId);

            await _productRepository.UpdateProduct(product);

            return product.ToResponse();
        }
    }
}