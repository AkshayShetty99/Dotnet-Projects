using cqrs_and_mediatr.Features.Products.DTOs;
using MediatR;

namespace cqrs_and_mediatr.Features.Products.Commands.Update
{
    public record UpdateProductCommand(Guid Id, string Name, string Description, decimal Price) : IRequest<ProductDto>;
}
