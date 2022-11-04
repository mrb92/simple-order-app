using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace SimpleOrderApp.Application.Common.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull, IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken token, RequestHandlerDelegate<TResponse> next)
        {
            var requestName = typeof(TRequest).Name;

            try
            {
                return await next();
            }
            catch (ValidationException exc)
            {
                _logger.LogError(exc, $"Database context validation exception for request {requestName}: {exc.Message}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"AspNetCore Request: Unhandled Exception for Request {requestName} {request}");
                throw;
            }
        }
    }
}
