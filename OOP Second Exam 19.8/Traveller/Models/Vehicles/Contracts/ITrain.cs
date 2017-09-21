using Traveller.Models.Enumerations;

namespace Traveller.Models.Vehicles.Contracts
{
    public interface ITrain : IVehicle
    {
        int Carts { get; }
    }
}