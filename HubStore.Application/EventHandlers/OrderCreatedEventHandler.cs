using HubStore.Application.Common.Models;
using HubStore.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace HubStore.Application.EventHandlers
{
	public class OrderCreatedEventHandler : INotificationHandler<DomainEventNotification<OrderCreatedEvent>>
	{
		private readonly ILogger<OrderCreatedEventHandler> _logger;

		public OrderCreatedEventHandler(ILogger<OrderCreatedEventHandler> logger)
		{
			_logger = logger;
		}

		public Task Handle(DomainEventNotification<OrderCreatedEvent> notification, CancellationToken cancellationToken)
		{
			var domainEvent = notification.DomainEvent;

			_logger.LogInformation("Domain Event: {DomainEvent}", domainEvent.GetType().Name);

			//TODO Notify User order is created

			return Task.CompletedTask;
		}
	}
}
