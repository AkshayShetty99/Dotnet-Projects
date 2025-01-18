namespace cqrs_and_mediatr.Features.Products.DTOs
{
    public record ProductDto(Guid Id, string Name, string Description, decimal Price);
}
