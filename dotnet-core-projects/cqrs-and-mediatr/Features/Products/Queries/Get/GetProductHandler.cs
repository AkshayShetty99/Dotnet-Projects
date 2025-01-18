using cqrs_and_mediatr.Features.Products.DTOs;
using cqrs_and_mediatr.Persistance;
using MediatR;

namespace cqrs_and_mediatr.Features.Products.Queries.Get
{
    public class GetProductHandler(AppDbContext context) : IRequestHandler<GetProductQuery, ProductDto>
    {
        public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken token)
        {
            var product = await context.Products.FindAsync(request.id);
            if(product == null)
            {
                return null;
            }
            return new ProductDto(product.Id, product.Name, product.Description, product.Price);
        }
    }
}
