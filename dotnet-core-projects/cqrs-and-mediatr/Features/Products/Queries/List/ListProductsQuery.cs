using cqrs_and_mediatr.Domain_;
using cqrs_and_mediatr.Features.Products.DTOs;
using MediatR;

namespace cqrs_and_mediatr.Features.Products.Queries.List
{
    public record ListProductsQuery : IRequest<List<ProductDto>>;
}
