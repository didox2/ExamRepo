using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;
using Traveller.Core.Providers;

namespace Traveller.Commands.Creating
{
    public class ListJourneysCommand : ICommand
    {
        private readonly ITravellerFactory factory;
        private readonly IDatabase database;

        public ListJourneysCommand(ITravellerFactory factory, IDatabase database)
        {
            this.factory = factory ?? throw new ArgumentNullException("factory");
            this.database = database ?? throw new ArgumentNullException("database");

            this.factory = factory;
            this.database = database;
        }

        public string Execute(IList<string> parameters)
        {
            var journeys = this.database.Journeys;

            if (journeys.Count == 0)
            {
                return "There are no registered journeys.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, journeys);
        }
    }
}
