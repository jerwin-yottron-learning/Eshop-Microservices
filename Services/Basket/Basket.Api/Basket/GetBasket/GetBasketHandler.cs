using Basket.Api.Data;

namespace Basket.Api.Basket.GetBasket
{
    public record GetBasketQuery(string Username): IQuery<GetBasketResult>;
    public record GetBasketResult(ShoppingCart Cart);
    public class GetBasketQueryHandler(IBasketRepository _repository) : 
        IQueryHandler<GetBasketQuery, GetBasketResult>
    {
        public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
       
            var basket = await _repository.GetBasket(query.Username); 

            return new GetBasketResult(basket);

        }
    }
}
