using HubStore.Application.Common.Models;
using HubStore.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace HubStore.Application.EventHandlers
{
	public class UserCreatedEventHandler : INotificationHandler<DomainEventNotification<UserCreatedEvent>>
	{
		private readonly ILogger<UserCreatedEventHandler> _logger;

		public UserCreatedEventHandler(ILogger<UserCreatedEventHandler> logger)
		{
			_logger = logger;
		}

		public Task Handle(DomainEventNotification<UserCreatedEvent> notification, CancellationToken cancellationToken)
		{
			var domainEvent = notification.DomainEvent;

			_logger.LogInformation("Domain Event: {DomainEvent}", domainEvent.GetType().Name);

			//TODO Send welcome email to user

			return Task.CompletedTask;
		}
	}
}
