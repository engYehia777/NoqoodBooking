using ErrorOr;
using FluentValidation;
using MediatR;

namespace NoqoodBooking.Application.Common.Behaviors
{
    public class ValidationBehaviors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehaviors(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // befor the handler
            if (_validator is null)
                return await next();

            var validationResult = await _validator.ValidateAsync(request);
            if (validationResult.IsValid)
                return await next();

            var errors = validationResult.Errors.ConvertAll(validationFailure => Error.Validation(
                validationFailure.PropertyName, validationFailure.ErrorMessage));

            return (dynamic)errors;

        }
    }
}
