using HubStore.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HubStore.Application.Services.Interfaces
{
	public interface IOrderService
	{
		Task<int> CreateNewOrder(CreateOrderDto newOrder);
		Task<List<OrderDto>> GetUserOrders(int userId);
	}
}
