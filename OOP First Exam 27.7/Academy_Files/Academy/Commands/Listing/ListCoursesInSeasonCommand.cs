using Academy.Commands.Abstract;
using System.Collections.Generic;
using Academy.Core.Contracts;

namespace Academy.Commands.Listing
{
    public class ListCoursesInSeasonCommand : Command
    {
        public ListCoursesInSeasonCommand(IAcademyFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var seasonId = parameters[0];
            var season = this.Engine.Seasons[int.Parse(seasonId)];

            return season.ListCourses().TrimEnd();
        }
    }
}
