using System.Text;
using Traveller.Models.Enumerations;
using Traveller.Models.Vehicles.Abstracts;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Models.Vehicles
{
    public class Airplane : Vehicle, IAirplane
    {
        public Airplane(int pasangerCapacity, decimal pricePerKilometer, bool hasFreeFood) : base(pasangerCapacity, pricePerKilometer)
        {
        }

        public override VehicleType Type
        {
            get 
            {
                return VehicleType.Air;
            }
        }

        public bool HasFreeFood { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Airplane ----");
            sb.AppendLine(base.ToString());
            sb.Append("Has free food: " + this.HasFreeFood);

            return sb.ToString();
        }

    }
}
