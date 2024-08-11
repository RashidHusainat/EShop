using Basket.Api.Basket.GetBasket;
using Basket.Api.Basket.StoreBasket;
using Basket.Api.Model;
using Marten;
using MediatR;

namespace Basket.Api.Data
{
    public class BasketRepository(IDocumentSession session)
        : IBasketRepository
    {
        public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken)
        {
           var ShoppingCart=await session.Query<ShoppingCart>().FirstOrDefaultAsync(i=>i.UserName.Equals(userName), cancellationToken);

            session.Delete<ShoppingCart>(ShoppingCart);
            await session.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<GetBasketQueryCommandResult> GetBasket(GetBasketQueryCommand query, CancellationToken cancellationToken)
        {
            var shppingCart = await session.LoadAsync<ShoppingCart>(query.UserName, cancellationToken);


            return new GetBasketQueryCommandResult()
            {
                ShoppingCart = shppingCart,

            };
        }

        public async Task<StoreBasketCommandResult> StoreBasket(StoreBasketCommand command, CancellationToken cancellationToken)
        {
            session.Store<ShoppingCart>(command.ShoppingCart);
            await session.SaveChangesAsync(cancellationToken);

            return new StoreBasketCommandResult()
            {
                ShoppingCart = command.ShoppingCart

            };
        }
    }
}
