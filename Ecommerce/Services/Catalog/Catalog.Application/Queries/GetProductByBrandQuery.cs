using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetProductByBrandQuery(string Name) : IRequest<IList<ProductResponse>>;
}
