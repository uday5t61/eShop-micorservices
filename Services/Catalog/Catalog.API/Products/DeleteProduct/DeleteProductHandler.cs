
namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductResult(bool IsSuccess);
    public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;
    public class DeleteProductCommandHandler(IDocumentSession session,ILogger<DeleteProductCommandHandler> logger) 
        : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            logger.LogInformation("DeleteProductCommandHandler.Handle called with {@command}", command);

            var product = await session.LoadAsync<Product>(command.Id, cancellationToken)
                ?? throw new ProductNotFoundException();

            session.Delete<Product>(command.Id);
            await session.SaveChangesAsync(cancellationToken);

            return new DeleteProductResult(true);
        }
    }
}
