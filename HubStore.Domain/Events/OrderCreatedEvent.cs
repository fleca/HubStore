using HubStore.Domain.Common;
using HubStore.Domain.Entities;

namespace HubStore.Domain.Events
{
	public class OrderCreatedEvent : DomainEvent
	{
		public OrderCreatedEvent(Order order)
		{
			Order = order;
		}

		public Order Order;
	}
}
