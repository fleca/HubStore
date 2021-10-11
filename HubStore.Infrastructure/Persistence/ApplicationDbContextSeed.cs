using HubStore.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace HubStore.Infrastructure.Persistence
{
	public static class ApplicationDbContextSeed
	{
		public static async Task SeedSampleDataAsync(ApplicationDbContext context)
		{
			if (!context.Products.Any())
			{
				context.Products.Add(new Product
				{
					Name = "Macbook",
					Description = "Power. It’s in the Air",
					Price = 200,
					Quantity = 10
				});

				context.Products.Add(new Product
				{
					Name = "iPad",
					Description = "Delightfully capable. Surprisingly affordable",
					Price = 100,
					Quantity = 5
				});

				await context.SaveChangesAsync();
			}
		}
	}
}
