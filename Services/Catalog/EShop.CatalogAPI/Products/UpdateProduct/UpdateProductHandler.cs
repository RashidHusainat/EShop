using EShop.CatalogAPI.Model;
using EShop.CatalogAPI.Products.CreateProduct;
using FluentValidation;
using Mapster;
using Marten;
using MediatR;

namespace EShop.CatalogAPI.Products.UpdateProduct;


public class UpdateProductCommand : IRequest<UpdateProductCommandResult>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public List<string> Category { get; set; } = new();
    public string Description { get; set; } = default!;
    public string ImageFile { get; set; } = default!;
    public decimal Price { get; set; }
}

public class UpdateProductCommandResult
{
    public bool IsSuccess { get; set; }
}

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(i => i.Name).NotEmpty().WithMessage("Product Name is required");
        RuleFor(i => i.Price).GreaterThan(0).WithMessage("Product price should be grater than 0");
        RuleFor(i => i.Category).NotEmpty().WithMessage("Product caregory is required");
        RuleFor(i => i.Id).NotEmpty().WithMessage("ID is required");
        RuleFor(i => i.Id).Must((id) => {
            return true;
        });
    }
}

public class UpdateProductHandler(IDocumentSession session)
    : IRequestHandler<UpdateProductCommand, UpdateProductCommandResult>
{
    public async Task<UpdateProductCommandResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product=await session.LoadAsync<Product>(request.Id);
        if (product is null)
            throw new Exception();

        var mappedProduct = request.Adapt<Product>();
        product= mappedProduct;
        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);

        return new UpdateProductCommandResult()
        {
            IsSuccess = true,
        };
    }
}

