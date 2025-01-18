using cqrs_and_mediatr.Features.Products.DTOs;
using MediatR;

namespace cqrs_and_mediatr.Features.Products.Commands.Create
{
    public record CreateProductCommand(string Name, string Description, decimal Price) : IRequest<Guid>;
}
