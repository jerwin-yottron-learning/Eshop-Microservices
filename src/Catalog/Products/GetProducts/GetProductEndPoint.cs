
using Catalog.Api.Products.CreateProduct;

namespace Catalog.Api.Products.GetProducts
{

    public record GetProductsRequest(int? PageNumber = 1, int? PageSize = 10);
    public record GetProductsResponse(IEnumerable<Product>Products);
    public class GetProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async ([AsParameters] GetProductsRequest request, ISender sender) =>
            {
                var result = await sender.Send(new GetProductsQuery());
                var response = result.Adapt<GetProductsResponse>();

                return Results.Ok(response);
            }).WithName("GetProduct")
               .Produces<CreateProductResponse>(StatusCodes.Status200OK)
               .WithSummary("Get Product")
               .WithDescription("Get Product");
        }
    }
}
