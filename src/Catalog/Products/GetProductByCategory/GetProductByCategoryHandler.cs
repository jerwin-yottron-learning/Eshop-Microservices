
using FluentValidation;
using JasperFx.Core;

namespace Catalog.Api.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(IEnumerable<Product> Product);
    internal class GetProductByCategoryHandlerQuery(IDocumentSession session) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public class GetProductByCategoryQueryValidator:AbstractValidator<GetProductByCategoryQuery>
        {
            public GetProductByCategoryQueryValidator()
            {
                RuleFor(x => x.Category).NotEmpty().WithMessage("Category shouldnt empty");
            }
        }
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            var product = await session.Query<Product>()
                .Where(p=>p.Category.Contains(query.Category)).ToListAsync(cancellationToken);
            return new GetProductByCategoryResult(product);
        }
    }
}
