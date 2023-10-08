using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Common.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var handlingRequestMessage = $"Handling the request: {typeof(TRequest).Name}";
            var requestType = request.GetType();
            var properties = requestType.GetProperties()
                .Select(prop => $"{prop.Name} : {prop.GetValue(request)}")
                .ToArray();

            var requestProperties = string.Join(Environment.NewLine, properties);

            _logger.LogInformation($"{handlingRequestMessage}{Environment.NewLine}Request properties:{Environment.NewLine}{requestProperties}");

            var response = await next();

            _logger.LogInformation($"Response: {typeof(TResponse).Name}");
            return response;
        }
    }
}
