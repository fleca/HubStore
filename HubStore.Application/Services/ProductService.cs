using AutoMapper;
using AutoMapper.QueryableExtensions;
using HubStore.Application.Common.Interfaces;
using HubStore.Application.Dtos;
using HubStore.Application.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubStore.Application.Services
{
	public class ProductService : IProductService
	{
		private readonly ILogger<ProductService> _logger;
		private readonly IApplicationDbContext _context;
		private readonly IMapper _mapper;

		public ProductService(
			ILogger<ProductService> logger,
			IApplicationDbContext context,
			IMapper mapper)
		{
			_logger = logger;
			_context = context;
			_mapper = mapper;
		}

		public async Task<List<ProductDto>> GetAllAsync()
		{
			_logger.LogInformation("Listing all products");

			return await _context.Products
				.AsNoTracking()
				.OrderByDescending(p => p.Id)
				.ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
				.ToListAsync();
		}
	}
}
