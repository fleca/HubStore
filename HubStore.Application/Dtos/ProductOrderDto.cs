using AutoMapper;
using HubStore.Application.Common.Mappings;
using HubStore.Domain.Entities;

namespace HubStore.Application.Dtos
{
	public class ProductOrderDto : IMapFrom<ProductOrder>
	{
		public OrderDto Order { get; set; }
		public ProductDto Product { get; set; }
		public int Quantiy { get; set; }
		public decimal UnityPrice { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<ProductOrder, ProductOrderDto>();
		}
	}
}
