using HubStore.Application.Common.Interfaces;
using HubStore.Infrastructure.Persistence;
using HubStore.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HubStore.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{

			if (configuration.GetValue<bool>("UseInMemoryDatabase"))
			{
				services.AddDbContext<ApplicationDbContext>(options =>
					options.UseInMemoryDatabase("BillsbyDb"));
			}
			else
			{
				services.AddDbContext<ApplicationDbContext>(options =>
					options.UseSqlServer(
						configuration.GetConnectionString("DefaultConnection"),
						b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
			}

			services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

			services.AddScoped<IDomainEventService, DomainEventService>();

			services.AddTransient<IDateTime, DateTimeService>();

			return services;
		}
	}
}
