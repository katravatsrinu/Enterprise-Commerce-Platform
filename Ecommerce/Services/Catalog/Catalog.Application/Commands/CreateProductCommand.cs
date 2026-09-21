using Catalog.Application.DTOs;
using Catalog.Application.Responses;
using MediatR;

namespace Catalog.Application.Commands
{
    public record CreateProductCommand(CreateProductDto Product) : IRequest<ProductResponse>
    {
    }
}