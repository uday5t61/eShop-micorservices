﻿namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdResult(Product Product);
    public record GetProductByIdQuery(Guid id): IQuery<GetProductByIdResult>;
    public class GetProductByIdQueryHandler(IDocumentSession session,ILogger<GetProductByIdQueryHandler> logger) 
        : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation($"GetProductByIdQueryHandler.Handle called with {query}");

            var product = await session.LoadAsync<Product>(query.id, cancellationToken);
            return product == null ? throw new ProductNotFoundException() : new GetProductByIdResult(product);
        }
    }
}
