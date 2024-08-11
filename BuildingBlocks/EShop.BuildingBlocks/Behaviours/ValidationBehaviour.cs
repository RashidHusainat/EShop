using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.BuildingBlocks.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var validationContext = new ValidationContext<TRequest>(request);
            var ValidationResults = await Task.WhenAll(validators.Select(i => i.ValidateAsync(request, cancellationToken)));
            var failers=ValidationResults.Where(i=>!i.IsValid).SelectMany(i=>i.Errors).ToList();

            if (failers.Any())
                throw new FluentValidation.ValidationException(failers);

            return await next();
            
        }
    }
}
