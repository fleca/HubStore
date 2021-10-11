using System.Collections.Generic;

namespace HubStore.Application.Dtos
{
	public class CreateOrderDto
	{
		public string UserEmail { get; set; }
		public List<CreateProductOrderDto> Products { get; set; }
	}
}
