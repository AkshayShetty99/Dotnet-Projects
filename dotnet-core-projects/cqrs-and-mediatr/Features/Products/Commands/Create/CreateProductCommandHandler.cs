using cqrs_and_mediatr.Domain_;
using cqrs_and_mediatr.Persistance;
using MediatR;

namespace cqrs_and_mediatr.Features.Products.Commands.Create
{
    public class CreateProductCommandHandler(AppDbContext context) : IRequestHandler<CreateProductCommand, Guid>
    {
        public async Task<Guid> Handle(CreateProductCommand command, CancellationToken token)
        {
            var product = new Product(command.Name, command.Description, command.Price);
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            return product.Id;
        }
    }
}
