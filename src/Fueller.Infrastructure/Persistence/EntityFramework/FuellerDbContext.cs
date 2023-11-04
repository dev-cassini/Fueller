using System.Reflection;
using Fueller.Domain.Model;
using Fueller.Domain.Model.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Fueller.Infrastructure.Persistence.EntityFramework;

public class FuellerDbContext : DbContext
{
    public DbSet<Forecourt> Forecourts { get; set; } = null!;
    public DbSet<Lane> Lanes { get; set; } = null!;
    public DbSet<Pump> Pumps { get; set; } = null!;
    public DbSet<Vehicle> Vehicles { get; set; } = null!;
    public DbSet<Transaction> Transactions { get; set; } = null!;
    
    public FuellerDbContext(DbContextOptions<FuellerDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entity.GetProperties().Where(x => x.IsPrimaryKey()))
            {
                property.ValueGenerated = ValueGenerated.Never;
            }
        }
    }
}