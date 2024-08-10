
using Catalog.Api.Products.CreateProduct;

namespace Catalog.Api.Products.GetProducts
{

    //
    public record GetProductsResponse(IEnumerable<Product>Products);
    public class GetProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/Products", async (ISender sender) =>
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
