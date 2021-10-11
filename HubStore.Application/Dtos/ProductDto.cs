using AutoMapper;
using HubStore.Application.Common.Mappings;
using HubStore.Domain.Entities;

namespace HubStore.Application.Dtos
{
	public class ProductDto : BaseDto, IMapFrom<Product>
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Product, ProductDto>();
		}
	}
}
