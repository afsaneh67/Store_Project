using Domain.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.BehavioursPipes
{
    public class ValidationBehaviour<TRequest,TResponse>
        :IPipelineBehavior<TRequest,TResponse> where TRequest : IRequest <TResponse>   
    {
        private readonly ILogger<TRequest> _logger;
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehaviour(ILogger<TRequest> logger, IEnumerable<IValidator<TRequest>> validators)
        {
            _logger = logger;
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any()) return await next().ConfigureAwait(false);
            var context = new ValidationContext<TRequest>(request);
            var validationResult = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures=validationResult.Where(r=>r.Errors.Any()).SelectMany(r=>r.Errors).ToList();
            if (failures.Any()) throw new ValidationEntityException(failures);
            return await next().ConfigureAwait(false);


        }
    }
}
