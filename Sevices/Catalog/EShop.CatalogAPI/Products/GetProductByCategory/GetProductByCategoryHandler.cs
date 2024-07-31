using EShop.CatalogAPI.Model;
using Marten;
using MediatR;

namespace EShop.CatalogAPI.Products.GetProductByCategory;


public class GetProductByCategoryQuery : IRequest<GetProductByCategoryQueryResult>
{
    public string? Category { get; set; }
}

public class GetProductByCategoryQueryResult
{
   public List<Product> Products { get; set; }=new List<Product>();
}

public class GetProductByCategoryHandler(IDocumentSession session) 
    : IRequestHandler<GetProductByCategoryQuery, GetProductByCategoryQueryResult>
{
    public async Task<GetProductByCategoryQueryResult> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
    {
       var products=await session.Query<Product>()
            .Where(a=>a.Category.Contains(request.Category))
            .ToListAsync(cancellationToken);
        return new GetProductByCategoryQueryResult()
        {
            Products = products.ToList(),
        };
    }
}

