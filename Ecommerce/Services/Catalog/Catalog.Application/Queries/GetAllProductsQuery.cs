using MediatR;
using Catalog.Core.Specifications;
using Catalog.Application.Responses;

namespace Catalog.Application.Queries
{
    public record GetAllProductsQuery(CatalogSpecParams CatalogSpecParams ) : IRequest<Pagination<ProductResponse>>
    {
    }
}
