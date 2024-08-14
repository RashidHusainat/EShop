using Carter;
using MediatR;
using Ordering.Application.Orders.Commands.CreateCommand;
using Ordering.Application.Orders.Queries;
using Ordering.Domain.ValueObjects;

namespace Oredring.Api.Endpoints
{
    public class GetOrdersEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders",async (ISender sender) => {
            
            var Result=await sender.Send(new GetOrdersQuery() { });
                return Results.Ok(Result);
            
            }).WithName("Get All Orders")
        .Produces<GetOrdersQuery>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get All Orders")
        .WithDescription("Get All Orders"); ;
        }
    }
}
