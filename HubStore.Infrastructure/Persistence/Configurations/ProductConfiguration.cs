using HubStore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HubStore.Infrastructure.Persistence.Configurations
{
	public class ProductConfiguration : AbstractConfiguration<Product, int>
	{
		public override void CustomConfigure(EntityTypeBuilder<Product> builder)
		{
			builder.HasIndex(n => n.Name)
				.IsUnique();

			builder.Property(d => d.Description)
				.HasMaxLength(250)
				.IsRequired();
		}
	}
}
