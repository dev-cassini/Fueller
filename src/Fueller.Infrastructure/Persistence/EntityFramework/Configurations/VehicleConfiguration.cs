using Fueller.Domain.Enums;
using Fueller.Domain.Model.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fueller.Infrastructure.Persistence.EntityFramework.Configurations;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable(nameof(FuellerDbContext.Vehicles));

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Type);
        builder.Property(x => x.FuelType);
        builder.Property(x => x.FuelLevel);
        builder.Property(x => x.TankCapacity);

        builder
            .HasDiscriminator(x => x.Type)
            .HasValue<Car>(VehicleType.Car)
            .HasValue<Van>(VehicleType.Van)
            .HasValue<Hgv>(VehicleType.Hgv);
    }
}