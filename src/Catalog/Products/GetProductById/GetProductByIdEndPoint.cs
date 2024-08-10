
namespace Catalog.Api.Products.GetProductById
{
    // public record GetProductByIdResponse (Product Product);
    public record GetProductByIdResponse(Product Product);

    public class GetProductByIdEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async(Guid id,ISender sender) =>
            {
                var product = await sender.Send(new GetProductByIdQuery(id)); //mapster isnt working
                var response = product.Adapt<GetProductByIdResponse>();
                return Results.Ok(product);

            }).WithName("GetProductById")
               .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
               .WithSummary("Get Product By Id")
               .WithDescription("Get Product By Id");
        }
    }
}
