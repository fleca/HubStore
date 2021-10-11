using HubStore.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HubStore.Infrastructure.Persistence.Configurations
{
	public class UserConfiguration : AbstractConfiguration<User, int>
	{
		public override void CustomConfigure(EntityTypeBuilder<User> builder)
		{
			builder.HasIndex(n => n.Email)
				.IsUnique();
		}
	}
}
