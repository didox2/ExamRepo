using System;
using System.Collections.Generic;
using Traveller.Commands.Creating.Abstract;
using Traveller.Core.Contracts;
using Traveller.Models.Vehicles.Contracts;
using Traveller.Utils;

namespace Traveller.Commands.Creating
{
    public class CreateBusCommand : CreateCommand
    {
        public CreateBusCommand(ITravellerFactory factory, IEngine engine) : base(factory, engine)
        {
        }
        public override string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateBus command parameters.");
            }

            var bus = this.Factory.CreateBus(passengerCapacity, pricePerKilometer);
            this.Engine.Vehicles.Add(bus);

            return $"Vehicle with ID {this.Engine.Vehicles.Count - 1} was created.";
        }
    }
}
