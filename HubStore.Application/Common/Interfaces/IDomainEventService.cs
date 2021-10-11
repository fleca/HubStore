using HubStore.Domain.Common;
using System.Threading.Tasks;

namespace HubStore.Application.Common.Interfaces
{
	public interface IDomainEventService
	{
		Task Publish(DomainEvent domainEvent);
	}
}
