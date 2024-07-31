using EShop.CatalogAPI.Model;
using Marten;
using MediatR;

namespace EShop.CatalogAPI.Products.DeleteProduct;


public class DeleteProductCommand : IRequest<DeleteProductCommandResult>
{
    public Guid Id { get; set; }
}

public class DeleteProductCommandResult
{
    public bool IsSuccess { get; set; }
}
public class DeleteProductHandler(IDocumentSession session)
    : IRequestHandler<DeleteProductCommand, DeleteProductCommandResult>
{
    public async Task<DeleteProductCommandResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product=await session.LoadAsync<Product>(request.Id, cancellationToken);
        if (product is null)
            throw new Exception();

        session.Delete<Product>(product);
        await session.SaveChangesAsync(cancellationToken);
        
        return new DeleteProductCommandResult() {
        IsSuccess=true,
        };
    }
}

