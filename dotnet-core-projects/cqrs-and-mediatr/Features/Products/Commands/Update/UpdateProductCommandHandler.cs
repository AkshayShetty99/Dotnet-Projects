using cqrs_and_mediatr.Features.Products.DTOs;
using cqrs_and_mediatr.Persistance;
using MediatR;

namespace cqrs_and_mediatr.Features.Products.Commands.Update
{
    public class UpdateProductCommandHandler(AppDbContext context) : IRequestHandler<UpdateProductCommand,ProductDto>
    {
        public async Task<ProductDto> Handle(UpdateProductCommand command, CancellationToken token)
        {
            var product = await context.Products.FindAsync(command.Id);
            if (product == null) return null;
            product.Name = command.Name;
            product.Description = command.Description;
            product.Price = command.Price;
            await context.SaveChangesAsync(token);

            return new ProductDto(product.Id, product.Name, product.Description, product.Price);
        }
    }
}
