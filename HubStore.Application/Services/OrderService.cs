using AutoMapper;
using AutoMapper.QueryableExtensions;
using HubStore.Application.Common.Exceptions;
using HubStore.Application.Common.Interfaces;
using HubStore.Application.Dtos;
using HubStore.Application.Services.Interfaces;
using HubStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace HubStore.Application.Services
{
	public class OrderService : IOrderService
	{
		private readonly ILogger<OrderService> _logger;
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;

		public OrderService(
			ILogger<OrderService> logger,
			IApplicationDbContext context,
			IMapper mapper)
		{
			_logger = logger;
			_context = context;
			_mapper = mapper;
		}

		public async Task<int> CreateNewOrder(CreateOrderDto newOrder)
		{
			using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

			List<ProductOrder> dbProductOrders = new List<ProductOrder>();

			User user = await UpsertUser(newOrder);
			Order order = await CreateOrder(user);

			foreach (CreateProductOrderDto productOrder in newOrder.Products)
			{
				var product = await _context.Products.FindAsync(productOrder.ProductId)
					?? throw new NotFoundException(nameof(Product), productOrder.ProductId);

				if (product.Quantity < productOrder.Quantity)
					throw new InvalidOperationException($"Product {product.Id} has only {product.Quantity} items in stock");

				product.SubtractQuantity(productOrder.Quantity);
				_context.Products.Update(product);

				dbProductOrders.Add(new ProductOrder(order, product, productOrder.Quantity));
			}

			await _context.ProductOrders.AddRangeAsync(dbProductOrders);

			await _context.SaveChangesAsync(new CancellationToken());
			transactionScope.Complete();

			return order.Id;
		}

		public async Task<List<OrderDto>> GetUserOrders(int userId)
		{
			var user = await _context.Users.FindAsync(userId)
				?? throw new NotFoundException(nameof(User), userId);

			return await _context.Orders
				.Include(o => o.ProductOrders).ThenInclude(p => p.Product)
				.Include(o => o.ProductOrders).ThenInclude(p => p.Order)
				.Include(o => o.User)
				.Where(o => o.User == user)
				.ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
				.ToListAsync();
		}

		#region Private Methods

		private async Task<User> UpsertUser(CreateOrderDto newOrder)
		{
			var user = await _context.Users
				.Where(u => u.Email == newOrder.UserEmail)
				.FirstOrDefaultAsync();

			if (user == null)
			{
				user = new User(newOrder.UserEmail, null);

				await _context.Users.AddAsync(user);
			}

			return user;
		}

		private async Task<Order> CreateOrder(User user)
		{
			Order order = new Order(user);

			await _context.Orders.AddAsync(order);

			return order;
		}

		#endregion
	}
}
