using cqrs_and_mediatr.Features.Products.DTOs;
using MediatR;

namespace cqrs_and_mediatr.Features.Products.Queries.Get
{
    public record GetProductQuery(Guid id) : IRequest<ProductDto>;
}
