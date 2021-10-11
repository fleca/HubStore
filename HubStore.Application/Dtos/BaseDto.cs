using HubStore.Application.Common.Mappings;
using HubStore.Domain.Common;
using System;

namespace HubStore.Application.Dtos
{
	public class BaseDto : IMapFrom<BaseEntity>
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? LastModifiedAt { get; set; }
	}
}
