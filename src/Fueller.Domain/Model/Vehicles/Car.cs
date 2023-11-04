using Fueller.Domain.Enums;

namespace Fueller.Domain.Model.Vehicles;

public class Car : Vehicle
{
    protected Car(
        Guid id,
        FuelType fuelType, 
        int fuelLevel, 
        int tankCapacity) 
        : base(id, VehicleType.Car, fuelType, fuelLevel, tankCapacity)
    {
    }
}