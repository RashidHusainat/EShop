using EShop.CatalogAPI.Model;
using FluentValidation;
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

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(i => i.Name).NotEmpty().WithMessage("Product Name is required");
        RuleFor(i => i.Price).GreaterThan(0).WithMessage("Product price should be grater than 0");
        RuleFor(i => i.Category).NotEmpty().WithMessage("Product caregory is required");
    }
}

public class CreateProductHandler(IDocumentSession session)
    : IRequestHandler<CreateProductCommand, CreateProductResult>
{
   
    public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        //var validator = new CreateProductCommandValidator();
        //var validationResult=await validator.ValidateAsync(request, cancellationToken);

        //if (!validationResult.IsValid)
        //    throw new ValidationException(validationResult.Errors);

       var product=request.Adapt<Product>();
        session.Store<Product>(product);
        await session.SaveChangesAsync(cancellationToken);
        return product.Adapt<CreateProductResult>();
    }
}

