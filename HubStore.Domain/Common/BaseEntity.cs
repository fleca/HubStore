using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HubStore.Domain.Common
{
	public class BaseEntity : IHasDomainEvent
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? LastModifiedAt { get; set; }

		[NotMapped]
		public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
	}
}
