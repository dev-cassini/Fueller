using Fueller.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fueller.Infrastructure.Persistence.EntityFramework.Configurations;

public class PumpConfiguration : IEntityTypeConfiguration<Pump>
{
    public void Configure(EntityTypeBuilder<Pump> builder)
    {
        builder.ToTable(nameof(FuellerDbContext.Pumps));

        builder.HasKey(x => x.Id);
    }
}