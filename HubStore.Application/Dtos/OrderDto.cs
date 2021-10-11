using AutoMapper;
using HubStore.Application.Common.Mappings;
using HubStore.Domain.Entities;
using System.Collections.Generic;

namespace HubStore.Application.Dtos
{
	public class OrderDto : BaseDto, IMapFrom<Order>
	{
		public UserDto User { get; set; }
		public List<ProductOrderDto> ProductOrders { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Order, OrderDto>();
		}
	}
}
