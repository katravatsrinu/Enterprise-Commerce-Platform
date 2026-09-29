using Catalog.Application.Commands;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Specifications;

namespace Catalog.Application.Mappers
{
    public static class ProductMapper
    {
        public static ProductResponse ToResponse(this Product product)
        {
            if (product == null)
                return null;

            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Summary = product.Summary,
                Description = product.Description,
                ImageFile = product.ImageFile,
                Price = product.Price,
                Brand = product.Brand,
                Type = product.Type,
                CreatedDate = product.CreatedDate
            };
        }

        // ADD IT HERE
        public static Product ToEntity(
            this CreateProductCommand command,
            ProductBrand brand,
            ProductType type)
        {
            return new Product
            {
                Name = command.Name,
                Summary = command.Summary,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Brand = brand,
                Type = type,
                Price = command.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
        }

        public static IList<ProductResponse> ToResponseList(
            this IEnumerable<Product> products)
        {
            return products
                .Select(p => p.ToResponse())
                .ToList();
        }

        public static Pagination<ProductResponse> ToResponse(
            this Pagination<Product> pagination)
        {
            return new Pagination<ProductResponse>(
                pagination.PageIndex,
                pagination.PageSize,
                pagination.Count,
                pagination.Data
                    .Select(p => p.ToResponse())
                    .ToList()
            );
        }
    }
}