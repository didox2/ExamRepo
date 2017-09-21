using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;
using Traveller.Core.Providers;

namespace Traveller.Commands.Creating
{
    public class ListVehiclesCommand : ICommand
    {
        private readonly ITravellerFactory factory;
        private readonly IDatabase database;

        public ListVehiclesCommand(ITravellerFactory factory, IDatabase database)
        {
            this.factory = factory ?? throw new ArgumentNullException("factory");
            this.database = database ?? throw new ArgumentNullException("database");

            this.factory = factory;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var vehicles = this.database.Vehicles;

            if (vehicles.Count == 0)
            {
                return "There are no registered vehicles.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, vehicles);
        }
    }
}
