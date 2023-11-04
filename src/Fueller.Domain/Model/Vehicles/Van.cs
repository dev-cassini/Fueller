using Fueller.Domain.Enums;

namespace Fueller.Domain.Model.Vehicles;

public class Van : Vehicle
{
    protected Van(
        Guid id,
        FuelType fuelType, 
        int fuelLevel, 
        int tankCapacity) 
        : base(id, VehicleType.Van, fuelType, fuelLevel, tankCapacity)
    {
    }
}