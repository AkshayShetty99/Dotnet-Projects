using MediatR;

namespace cqrs_and_mediatr.Features.Products.Commands.Delete
{
    public record DeleteProductCommand(Guid Id) : IRequest;
}
