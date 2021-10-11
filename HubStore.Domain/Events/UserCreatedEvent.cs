using HubStore.Domain.Common;
using HubStore.Domain.Entities;

namespace HubStore.Domain.Events
{
	public class UserCreatedEvent : DomainEvent
	{
		public UserCreatedEvent(User user)
		{
			User = user;
		}

		public User User;
	}
}
