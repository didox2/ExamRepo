using Academy.Commands.Abstract;
using Academy.Core.Contracts;
using System.Collections.Generic;

namespace Academy.Commands.Listing
{
    public class ListUsersInSeasonCommand : Command
    {
        public ListUsersInSeasonCommand(IAcademyFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var seasonId = parameters[0];
            var season = this.Engine.Seasons[int.Parse(seasonId)];

            return season.ListUsers().TrimEnd();
        }
    }
}
