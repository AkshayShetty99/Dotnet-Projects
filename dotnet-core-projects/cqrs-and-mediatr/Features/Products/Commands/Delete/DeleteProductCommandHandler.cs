using cqrs_and_mediatr.Persistance;
using MediatR;

namespace cqrs_and_mediatr.Features.Products.Commands.Delete
{
    public class DeleteProductCommandHandler(AppDbContext context) : IRequestHandler<DeleteProductCommand>
    {
        public async Task Handle(DeleteProductCommand command, CancellationToken token)
        {
            var product = await context.Products.FindAsync(command.Id);
            if (product == null) return;
            context.Remove(product);
            await context.SaveChangesAsync();
        }
    }
}
