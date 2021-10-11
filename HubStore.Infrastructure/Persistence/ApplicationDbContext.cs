using HubStore.Application.Common.Interfaces;
using HubStore.Domain.Common;
using HubStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace HubStore.Infrastructure.Persistence
{
	public class ApplicationDbContext : DbContext, IApplicationDbContext
	{
		private readonly IDateTime _dateTime;
		private readonly IDomainEventService _domainEventService;

		public ApplicationDbContext(
			DbContextOptions options,
			IDomainEventService domainEventService,
			IDateTime dateTime) : base(options)
		{
			_domainEventService = domainEventService;
			_dateTime = dateTime;
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<ProductOrder> ProductOrders { get; set; }

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
		{
			foreach (EntityEntry<BaseEntity> entry in ChangeTracker.Entries<BaseEntity>())
			{
				switch (entry.State)
				{
					case EntityState.Added:
						entry.Entity.CreatedAt = _dateTime.Now;
						break;

					case EntityState.Modified:
						entry.Entity.LastModifiedAt = _dateTime.Now;
						break;
				}
			}

			var result = await base.SaveChangesAsync(cancellationToken);

			await DispatchEvents();

			return result;
		}

		protected override void OnModelCreating(ModelBuilder builder)
		 {
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			builder.Entity<ProductOrder>()
				.HasKey(po => new { po.OrderId, po.ProductId });

			base.OnModelCreating(builder);
		}

		private async Task DispatchEvents()
		{
			while (true)
			{
				var domainEventEntity = ChangeTracker.Entries<IHasDomainEvent>()
					.Select(x => x.Entity.DomainEvents)
					.SelectMany(x => x)
					.Where(domainEvent => !domainEvent.IsPublished)
					.FirstOrDefault();
				if (domainEventEntity == null) break;

				domainEventEntity.IsPublished = true;
				await _domainEventService.Publish(domainEventEntity);
			}
		}
	}
}
