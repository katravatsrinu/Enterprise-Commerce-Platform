using Catalog.Application.DTOs;
using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Commands
{
    public record UpdateProductCommand(string Id, UpdateProductDto Product) : IRequest<ProductResponse>
    {
    }
}