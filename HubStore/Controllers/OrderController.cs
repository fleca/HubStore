using HubStore.Application.Dtos;
using HubStore.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HubStore.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpPost]
		public async Task<ActionResult<int>> CreateNewOrder(CreateOrderDto newOrder)
		{
			return await _orderService.CreateNewOrder(newOrder);
		}

		[HttpGet("{userId}")]
		public async Task<ActionResult<List<OrderDto>>> GetUserProducts(int userId)
		{
			return await _orderService.GetUserOrders(userId);
		}
	}
}
