using Basket.Api.Data;
using Basket.Api.Model;
using Marten;
using Marten.Pagination;
using MediatR;

namespace Basket.Api.Basket.GetBasket;

public class GetBasketQueryCommand : IRequest<GetBasketQueryCommandResult>
{
    public string? UserName { get; set; } 
}

public class GetBasketQueryCommandResult
{
    public ShoppingCart? ShoppingCart { get; set; }
}
public class GetBasketHandler(IBasketRepository repository) : IRequestHandler<GetBasketQueryCommand, GetBasketQueryCommandResult>
{
    public async Task<GetBasketQueryCommandResult> Handle(GetBasketQueryCommand request, CancellationToken cancellationToken)
    {
        var result=await repository.GetBasket(request, cancellationToken);  
        return result;
    }
}

