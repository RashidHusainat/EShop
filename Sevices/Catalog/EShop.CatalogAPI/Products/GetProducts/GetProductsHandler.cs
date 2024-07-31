using EShop.CatalogAPI.Model;
using Marten;
using MediatR;

namespace EShop.CatalogAPI.Products.GetProduct;

public class GetProductsQuery : IRequest<GetProductsResult>
{
}
public class GetProductsResult
{
    public List<Product> Products { get; set; }
}
public class GetProductsQueryHandler(IDocumentSession session)
    : IRequestHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>().ToListAsync();

        return new GetProductsResult()
        {
            Products = products.ToList(),
        };
    }
}

