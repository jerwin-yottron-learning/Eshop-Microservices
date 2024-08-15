namespace Basket.Api.Basket.GetBasket
{
    public record GetBasketQuery(string Username): IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart Cart);
    public class GetBasketQueryHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
            //todo
            //var basket = await _repository.GetBasket(query.username) 

            return new GetBasketResult(new ShoppingCart("test"));

        }
    }
}
