using Basket.Api.Data;
using Basket.Api.Model;
using Basket.Api.Models;
using Discount.Grpc;
using FluentValidation;
using Marten;
using MediatR;

namespace Basket.Api.Basket.StoreBasket
{
    public class StoreBasketCommand : IRequest<StoreBasketCommandResult>
    {
        public ShoppingCart? ShoppingCart { get; set; }

    }
    public class StoreBasketCommandResult
    {
        public ShoppingCart? ShoppingCart { get; set; }
    }

    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(i => i.ShoppingCart.UserName).NotEmpty().WithMessage("User Name is required !");
            RuleFor(i => i.ShoppingCart.Items).NotEmpty().WithMessage("Items is required");
            RuleForEach(i => i.ShoppingCart.Items).SetValidator(new ShoppingCartItemValidator());
        }

        public class ShoppingCartItemValidator : AbstractValidator<ShoppingCartItem>
        {
            public ShoppingCartItemValidator()
            {
                RuleFor(i => i.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0");
                RuleFor(i => i.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
                RuleFor(i => i.ProductName).NotEmpty().WithMessage("ProductName is required");
                RuleFor(i => i.ProductId).NotEmpty().WithMessage("ProductId is required");

            }
        }
    }
    public class StoreBasketCommandHandler(IBasketRepository repository,DiscountProtoService.DiscountProtoServiceClient discountService)
        : IRequestHandler<StoreBasketCommand, StoreBasketCommandResult>
    {
        public async Task<StoreBasketCommandResult> Handle(StoreBasketCommand request, CancellationToken cancellationToken)
        {
            foreach (var shoppingCartItem in request.ShoppingCart.Items)
            {
                var coupon = await discountService.GetDiscountAsync(new GetDiscountRequest()
                {
                    ProductName= shoppingCartItem.ProductName
                });
                shoppingCartItem.Price -= coupon.Amount;
            }
            var result = await repository.StoreBasket(request, cancellationToken);
            return result;
        }
    }
}
