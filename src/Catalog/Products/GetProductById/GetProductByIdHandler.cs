﻿using JasperFx.CodeGeneration.Frames;
using Marten.Linq.QueryHandlers;

namespace Catalog.Api.Products.GetProductById
{
    public record GetProductByIdQuery(Guid id) :IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product product);
    internal class GetProductByIdQueryHandler(IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger)
        : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductByIdQueryHandler.Handle called with{@Query}",query);

            var product = await session.LoadAsync<Product>(query.id,cancellationToken);
            if (product == null) {

                throw new ProductNotFoundException();
            }
            return new GetProductByIdResult(product);
        }
    }
}