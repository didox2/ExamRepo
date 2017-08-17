using Academy.Commands.Abstract;
using System.Collections.Generic;
using Academy.Core.Contracts;

namespace Academy.Commands.Creating
{
    public class CreateSeasonCommand : Command
    {
        public CreateSeasonCommand(IAcademyFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var startingYear = parameters[0];
            var endingYear = parameters[1];
            var initiative = parameters[2];

            var season = this.Factory.CreateSeason(startingYear, endingYear, initiative);
            this.Engine.Seasons.Add(season);

            return $"Season with ID {this.Engine.Seasons.Count - 1} was created.";
        }
    }
}
