using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;
using Traveller.Core.Providers;

namespace Traveller.Commands.Creating
{
    public class CreateBusCommand : ICommand
    {
        private readonly ITravellerFactory factory;
        private readonly IDatabase database;

        public CreateBusCommand(ITravellerFactory factory, IDatabase database)
        {
            this.factory = factory ?? throw new ArgumentNullException("factory");
            this.database = database ?? throw new ArgumentNullException("database");

            this.factory = factory;
            this.database = database;
        }
        public string Execute(IList<string> parameters)
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

            var bus = this.factory.CreateBus(passengerCapacity, pricePerKilometer);
            this.database.Vehicles.Add(bus);

            return $"Vehicle with ID {this.database.Vehicles.Count - 1} was created.";
        }
    }
}
