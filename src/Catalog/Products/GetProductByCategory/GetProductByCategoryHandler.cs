
namespace Catalog.Api.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string category) : IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(IEnumerable<Product> Product);
    internal class GetProductByCategoryHandlerQuery(IDocumentSession session, ILogger<GetProductByCategoryHandlerQuery> logger) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation($"GetProductByCategoryHandler called with {query}");
            var product = await session.Query<Product>()
                .Where(p=>p.Category.Contains(query.category)).ToListAsync();
            return new GetProductByCategoryResult(product);
        }
    }
}
