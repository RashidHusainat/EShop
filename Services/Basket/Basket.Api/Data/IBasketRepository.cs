using Basket.Api.Basket.GetBasket;
using Basket.Api.Basket.StoreBasket;

namespace Basket.Api.Data
{
    public interface IBasketRepository
    {
        Task<StoreBasketCommandResult> StoreBasket(StoreBasketCommand command, CancellationToken cancellationToken);

        Task<GetBasketQueryCommandResult> GetBasket(GetBasketQueryCommand query, CancellationToken cancellationToken);

        Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken);
    }
}
