using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetProductByIdQuery(string Id) : IRequest<ProductResponse>
    {
    }
}
