using HubStore.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HubStore.Application.Services.Interfaces
{
	public interface IProductService
	{
		public Task<List<ProductDto>> GetAllAsync();
	}
}
