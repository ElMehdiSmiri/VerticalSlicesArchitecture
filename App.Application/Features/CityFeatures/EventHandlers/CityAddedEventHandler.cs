using App.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace App.Application.Features.CityFeatures.EventHandlers
{
    public class CityAddedEventHandler : INotificationHandler<CityAdded>
    {
        private readonly ILogger<CityAddedEventHandler> _logger;

        public CityAddedEventHandler(ILogger<CityAddedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CityAdded notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Domain Event: {notification.GetType().Name}");

            return Task.CompletedTask;
        }
    }
}
