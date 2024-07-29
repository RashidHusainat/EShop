using EShop.CatalogAPI.Model;
using Mapster;
using Marten;
using MediatR;

namespace EShop.CatalogAPI.Products.CreateProduct;

public class CreateProductCommand:IRequest<CreateProductResult>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public List<string> Category { get; set; } = new();
    public string Description { get; set; } = default!;
    public string ImageFile { get; set; } = default!;
    public decimal Price { get; set; }

}

public class CreateProductResult
{
    public Product Product { get; set; }
}

public class CreateProductHandler(IDocumentSession session)
    : IRequestHandler<CreateProductCommand, CreateProductResult>
{
   
    public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product=request.Adapt<Product>();
        session.Store<Product>(product);
        await session.SaveChangesAsync(cancellationToken);
        return product.Adapt<CreateProductResult>();
    }
}

