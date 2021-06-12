using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Behaviours
{
    public class ValidationBehaviours<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _valitators;

        public ValidationBehaviours(IEnumerable<IValidator<TRequest>> valitators)
        {
            _valitators = valitators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if(_valitators.Any())
            {
                var context =  new FluentValidation.ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_valitators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                if (failures.Count != 0)
                    throw new Exceptions.ValidationException(failures);

                    
            }
            return await next();
                
        }
    }


}
