using Fueller.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fueller.Infrastructure.Persistence.EntityFramework.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable(nameof(FuellerDbContext.Transactions));

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Status);
        builder.Property(x => x.DateTimeCreated);
        builder.Property(x => x.DateTimeFilling);
        builder.Property(x => x.DateTimeCompleted);
        builder.Property(x => x.NumberOfLitresDispensed);

        builder.HasOne(x => x.Vehicle)
            .WithMany()
            .HasForeignKey(x => x.VehicleId);

        builder
            .HasOne<Pump>()
            .WithMany()
            .HasForeignKey(x => x.PumpId);
    }
}