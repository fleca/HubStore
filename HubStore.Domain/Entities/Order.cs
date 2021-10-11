using HubStore.Domain.Common;
using HubStore.Domain.Events;
using System.Collections.Generic;

namespace HubStore.Domain.Entities
{
	public class Order : BaseEntity
	{
		protected Order()
		{ }

		public Order(User user)
		{
			User = user;
			UserId = user.Id;
			DomainEvents.Add(new OrderCreatedEvent(this));
		}

		public User User { get; set; }
		public int UserId { get; set; }
		public List<ProductOrder> ProductOrders { get; set; }
	}
}
