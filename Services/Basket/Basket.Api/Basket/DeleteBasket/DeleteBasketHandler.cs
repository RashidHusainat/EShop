using Basket.Api.Data;
using Marten;
using MediatR;

namespace Basket.Api.Basket.DeleteBasket
{
    public class DeleteBasketCommand : IRequest<DeleteBasketCommandResult>
    {
        public string? UserName { get; set; }
    }

    public class DeleteBasketCommandResult
    {
        public bool IsSuccess { get; set; }
    }
    public class DeleteBasketHandler(IBasketRepository repository) : IRequestHandler<DeleteBasketCommand, DeleteBasketCommandResult>
    {
        public async Task<DeleteBasketCommandResult> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            var result= await repository.DeleteBasket(request.UserName,cancellationToken);
            return new DeleteBasketCommandResult(){
                IsSuccess=result
            };
        }
    }
}
