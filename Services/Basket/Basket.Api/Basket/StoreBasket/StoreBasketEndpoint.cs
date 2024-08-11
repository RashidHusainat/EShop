using Carter;
using MediatR;

namespace Basket.Api.Basket.StoreBasket
{
    public class StoreBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket", async (StoreBasketCommand command, ISender sender) =>
            {

                var result = await sender.Send(command);
                return Results.Ok(result);
            });
        }
    }
}
