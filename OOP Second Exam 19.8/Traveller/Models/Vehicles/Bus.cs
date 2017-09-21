using System;
using System.Text;
using Traveller.Models.Enumerations;
using Traveller.Models.Vehicles.Abstracts;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Models.Vehicles
{
    public class Bus : Vehicle, IBus
    {
        public Bus(int pasangerCapacity, decimal pricePerKilometer) : base(pasangerCapacity, pricePerKilometer)
        {
        }

        protected override void ValidatePassangerCapacity(int value)
        {
            if (value < 10 || value > 50)
            {
                throw new ArgumentOutOfRangeException("A bus cannot have less than 10 passengers or more than 50 passengers.");
            }
        }


        public override VehicleType Type
        {
            get
            {
                return VehicleType.Land;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Bus ----");
            sb.Append(base.ToString());

            return sb.ToString();
        }

    }
}
