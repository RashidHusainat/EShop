using Basket.Api.Basket.GetBasket;
using Basket.Api.Basket.StoreBasket;
using Basket.Api.Model;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Basket.Api.Data
{
    public class CachedBasketRepository(IBasketRepository repository,IDistributedCache cache) : IBasketRepository
    {
        public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken)
        {
          await  cache.RemoveAsync(userName, cancellationToken); 

         return  await repository.DeleteBasket(userName, cancellationToken);
           
        }

        public async Task<GetBasketQueryCommandResult> GetBasket(GetBasketQueryCommand query, CancellationToken cancellationToken)
        {
            var cachedCart=await cache.GetStringAsync(query.UserName, cancellationToken);
            if(!string.IsNullOrEmpty(cachedCart))
            {
                return new GetBasketQueryCommandResult()
                {
                    ShoppingCart=JsonSerializer.Deserialize<ShoppingCart>(cachedCart)

                };
            }
            var shoppingCart=await repository.GetBasket(query, cancellationToken);
            await cache.SetStringAsync(shoppingCart.ShoppingCart.UserName, JsonSerializer.Serialize(shoppingCart.ShoppingCart),cancellationToken);
            return shoppingCart;
        }

        public async Task<StoreBasketCommandResult> StoreBasket(StoreBasketCommand command, CancellationToken cancellationToken)
        {
           await cache.SetStringAsync(command.ShoppingCart.UserName,JsonSerializer.Serialize(command.ShoppingCart), cancellationToken);
            
            return await repository.StoreBasket(command, cancellationToken);
        }
    }
}
