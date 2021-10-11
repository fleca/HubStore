using HubStore.Domain.Common;
using HubStore.Domain.Events;
using System.Collections.Generic;

namespace HubStore.Domain.Entities
{
	public class User : BaseEntity
	{
		protected User()
		{ }

		public User(string email, string fullName)
		{
			Email = email;
			FullName = fullName;
			DomainEvents.Add(new UserCreatedEvent(this));
		}

		public string Email { get; set; }
		public string FullName { get; set; }
		public List<Order> Orders { get; set; }
	}
}
