using EShop.CatalogAPI.Model;
using Marten;
using MediatR;

namespace EShop.CatalogAPI.Products.GetProduct;

public class GetProductQuery: IRequest<GetProductQueryResult>
{
    public Guid Id { get; set; }
}
   

public class GetProductQueryResult
{
    public Product? Product { get; set; }
}

public class GetProductQueryHandler(IDocumentSession session) 
    : IRequestHandler<GetProductQuery, GetProductQueryResult>
{
    public async Task<GetProductQueryResult> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(request.Id, cancellationToken);
        return new GetProductQueryResult()
        {
            Product= product
        };
    }
}