using FluentValidation;
using MediatR;
using TransitTracer.Application.Infrastructure.Exceptions;

namespace TransitTracer.Application.Infrastructure.MediatrPipelines;

public class ValidationPipe<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipe(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
        var failures = validationResults.SelectMany(x => x.Errors).Where(x => x != null).ToList();
        if (!failures.Any()) return await next();
        throw new ApplicationValidationException(failures);
    }
}