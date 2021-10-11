using HubStore.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HubStore.Infrastructure.Persistence.Configurations
{
	public abstract class AbstractConfiguration<T, TId> : IEntityTypeConfiguration<T> where T : BaseEntity
	{
		public void Configure(EntityTypeBuilder<T> builder)
		{
			DefaultConfigure(builder);
			CustomConfigure(builder);
		}

		private void DefaultConfigure(EntityTypeBuilder<T> builder)
		{
			builder.Property(x => x.Id)
				.ValueGeneratedOnAdd();

			builder.Ignore(x => x.DomainEvents);

			builder.Property(x => x.CreatedAt)
				.IsRequired();
		}

		public abstract void CustomConfigure(EntityTypeBuilder<T> builder);
	}
}
