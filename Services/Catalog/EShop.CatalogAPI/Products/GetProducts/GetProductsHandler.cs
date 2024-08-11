using EShop.CatalogAPI.Model;
using Marten;
using Marten.Pagination;
using MediatR;

namespace EShop.CatalogAPI.Products.GetProduct;

public class GetProductsQuery : IRequest<GetProductsResult>
{
    public int PageSize { get; set; } 
    public int PageNumber { get; set; } 
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
        var products = await session.Query<Product>().ToPagedListAsync(request.PageNumber ,request.PageSize,cancellationToken);

        return new GetProductsResult()
        {
            Products = products.ToList(),
        };
    }
}

