using Fueller.Domain.Enums;
using Fueller.Domain.Model.Audit;

namespace Fueller.Domain.Model.Vehicles;

public abstract class Vehicle : AuditableEntity
{
    public Guid Id { get; }
    public VehicleType Type { get; }
    public FuelType FuelType { get; set; }
    public int FuelLevel { get; set; }
    public int TankCapacity { get; }

    protected Vehicle(
        Guid id, 
        VehicleType type, 
        FuelType fuelType, 
        int fuelLevel, 
        int tankCapacity)
    {
        Id = id;
        Type = type;
        FuelType = fuelType;
        FuelLevel = fuelLevel;
        TankCapacity = tankCapacity;
    }
}