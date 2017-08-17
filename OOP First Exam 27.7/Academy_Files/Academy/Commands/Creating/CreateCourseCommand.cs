using Academy.Commands.Abstract;
using Academy.Core.Contracts;
using System.Collections.Generic;

namespace Academy.Commands.Creating
{
    public class CreateCourseCommand : Command
    {
        public CreateCourseCommand(IAcademyFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var seasonId = parameters[0];
            var name = parameters[1];
            var lecturesPerWeek = parameters[2];
            var startingDate = parameters[3];

            var season = this.Engine.Seasons[int.Parse(seasonId)];
            var course = this.Factory.CreateCourse(name, lecturesPerWeek, startingDate);
            season.Courses.Add(course);

            return $"Course with ID {season.Courses.Count - 1} was created in Season {seasonId}.";
        }
    }
}
