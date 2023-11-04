using Fueller.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fueller.Infrastructure.Persistence.EntityFramework.Configurations;

public class ForecourtConfiguration : IEntityTypeConfiguration<Forecourt>
{
    public void Configure(EntityTypeBuilder<Forecourt> builder)
    {
        builder.ToTable(nameof(FuellerDbContext.Forecourts));

        builder.HasKey(x => x.Id);
        builder
            .HasMany(x => x.Lanes)
            .WithOne(x => x.Forecourt)
            .HasForeignKey(x => x.ForecourtId);
    }
}