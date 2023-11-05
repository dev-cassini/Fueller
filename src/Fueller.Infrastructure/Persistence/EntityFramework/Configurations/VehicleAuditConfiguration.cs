using Fueller.Domain.Model.Audit;
using Fueller.Domain.Model.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Fueller.Infrastructure.Persistence.EntityFramework.Configurations;

public class VehicleAuditConfiguration : IEntityTypeConfiguration<AuditRecord<Vehicle>>
{
    public void Configure(EntityTypeBuilder<AuditRecord<Vehicle>> builder)
    {
        builder.ToTable(nameof(FuellerDbContext.VehiclesAudit));
        
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Auditable)
            .HasColumnName(nameof(Vehicle))
            .HasConversion(
                x => JsonConvert.SerializeObject(x, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }),
                x => JsonConvert.DeserializeObject<Vehicle>(x));
        
        builder
            .HasMany<AuditMetadata<Vehicle>>(x => x.Metadata)
            .WithOne()
            .HasForeignKey(x => x.AuditRecordId);
    }
}