using Fueller.Domain.Model.Audit;
using Fueller.Domain.Model.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fueller.Infrastructure.Persistence.EntityFramework.Configurations;

public class VehicleAuditMetadataConfiguration : IEntityTypeConfiguration<AuditMetadata<Vehicle>>
{
    public void Configure(EntityTypeBuilder<AuditMetadata<Vehicle>> builder)
    {
        builder.ToTable(nameof(FuellerDbContext.VehiclesAuditMetadata));

        builder.HasKey(x => x.Id);
        builder.Property(x => x.PropertyName);
        builder.Property(x => x.OriginalValue);
        builder.Property(x => x.UpdatedValue);
    }
}