using Traveller.Models.Enumerations;

namespace Traveller.Models.Vehicles.Contracts
{
    public interface IVehicle
    {
        int PassangerCapacity { get; }

        decimal PricePerKilometer { get; }

        VehicleType Type { get;}
    }
}