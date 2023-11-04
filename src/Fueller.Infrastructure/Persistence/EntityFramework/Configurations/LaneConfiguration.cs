using Fueller.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fueller.Infrastructure.Persistence.EntityFramework.Configurations;

public class LaneConfiguration : IEntityTypeConfiguration<Lane>
{
    public void Configure(EntityTypeBuilder<Lane> builder)
    {
        builder.ToTable(nameof(FuellerDbContext.Lanes));

        builder.HasKey(x => x.Id);
        builder
            .HasMany(x => x.Pumps)
            .WithOne(x => x.Lane)
            .HasForeignKey(x => x.LaneId);
    }
}