using Basket.Api.Model;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Basket.GetBasket;

public class GetBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{UserName}", async (string UserName, ISender sender) =>
        {
            var result = await sender.Send(new GetBasketQueryCommand() { UserName = UserName });

            return Results.Ok(result);
        });
    }
}

