using Carter;
using Mapster;
using MediatR;

namespace Basket.Api.Basket.StoreBasket
{
    public record StoreBasketRequest (ShoppingCart cart);
    public record StoreBasketResponse (string UserName);
    public class StoreBasketEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket", async (StoreBasketRequest request,ISender sender) =>
            {
                var command = request.Adapt<StoreBasketCommand>();
                var result = sender.Send(command);
                var response = result.Adapt<StoreBasketResponse>();
                return Results.Created($"/basket/{response.UserName}", response);
            }).WithName("StoreBasket")
              .Produces<StoreBasketResponse>(StatusCodes.Status200OK)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .ProducesProblem(StatusCodes.Status404NotFound)
              .WithSummary("Store Basket")
              .WithDescription("Store Basket");
        }
    }
}
