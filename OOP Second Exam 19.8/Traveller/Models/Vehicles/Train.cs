using Traveller.Models.Enumerations;
using Traveller.Models.Vehicles.Abstracts;
using Traveller.Models.Vehicles.Contracts;
using Traveller.Utils;

namespace Traveller.Models.Vehicles
{
    public class Train : Vehicle, ITrain
    {
        private int carts;

        public Train(int pasangerCapacity, decimal pricePerKilometer, int carts) : base(pasangerCapacity, pricePerKilometer)
        {
            this.Carts = carts;
            this.PasangerCapacity = pasangerCapacity;
        }

        public int Carts
        {
            get
            {
                return this.carts;
            }
            set
            {
                Validator.ValidateMinAndMaxCarst(value, GlobalConstants.MinCarts, GlobalConstants.MaxCarts, this.GetType().Name.ToLower());
                this.carts = value;
            }
        }

        public override int PasangerCapacity
        {
            get
            {
                return base.PasangerCapacity;
            }
            set
            {
                Validator.ValidateMinAndMaxCapacity(value, GlobalConstants.MinTrainPassangerCapacity, GlobalConstants.MaxTrainPassangerCapacity, this.GetType().Name.ToLower());
            }
        }

        public override VehicleType Type
        {
            get
            {
                return VehicleType.Land;
            }
        }

        protected override string PrintAdditionalInfo()
        {
            return string.Format("Carts amount: " + this.Carts);
        }
    }
}
