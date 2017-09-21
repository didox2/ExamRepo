using System;
using System.Collections.Generic;
using Traveller.Commands.Creating.Abstract;
using Traveller.Core.Contracts;
using Traveller.Models.Vehicles.Contracts;
using Traveller.Utils;

namespace Traveller.Commands.Creating
{
    public class CreateTrainCommand : CreateCommand
    {
        public CreateTrainCommand(ITravellerFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;
            int cartsCount;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
                cartsCount = int.Parse(parameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTrain command parameters.");
            }
            var train = this.Factory.CreateTrain(passengerCapacity, pricePerKilometer, cartsCount);
            this.Engine.Vehicles.Add(train);

            return $"Vehicle with ID {this.Engine.Vehicles.Count - 1} was created.";
        }
    }
}
