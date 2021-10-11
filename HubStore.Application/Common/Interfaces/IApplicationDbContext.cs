using HubStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HubStore.Application.Common.Interfaces
{
	public interface IApplicationDbContext
	{
		DbSet<Product> Products { get; set; }
		DbSet<User> Users { get; set; }
		DbSet<Order> Orders { get; set; }
		DbSet<ProductOrder> ProductOrders { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
