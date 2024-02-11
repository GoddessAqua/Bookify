using Bookify.Application.Abstraction.Messaging;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Bookify.Application.Abstraction.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IBaseCommand
    {
        private readonly ILogger<TRequest> _logger;

        public LoggingBehavior(ILogger<TRequest> logger)
            => _logger = logger;

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var commandName = request.GetType().Name;

            try
            {
                _logger.LogInformation($"Executing command {commandName}");

                var result = await next();

                _logger.LogInformation($"Command {commandName} processed successfully");

                return result;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Command {commandName} processed failed");
                throw;
            }
        }
    }
}
