using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetProductByNameQuery(string Name) : IRequest<IList<ProductResponse>>
    {
    }
}
