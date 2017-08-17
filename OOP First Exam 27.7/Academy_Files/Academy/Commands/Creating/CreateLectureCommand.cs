using Academy.Commands.Abstract;
using Academy.Core.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Commands.Creating
{
    public class CreateLectureCommand : Command
    {
        public CreateLectureCommand(IAcademyFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var seasonId = parameters[0];
            var courseId = parameters[1];
            var name = parameters[2];
            var date = parameters[3];
            var trainerUsername = parameters[4];

            var course = this.Engine.Seasons[int.Parse(seasonId)].Courses[int.Parse(courseId)];
            var trainer = this.Engine.Trainers.Single(x => x.Username.ToLower() == trainerUsername.ToLower());

            var lecture = this.Factory.CreateLecture(name, date, trainer);
            course.Lectures.Add(lecture);

            return $"Lecture with ID {course.Lectures.Count - 1} was created in course {seasonId}.{course.Name}.";
        }
    }
}
