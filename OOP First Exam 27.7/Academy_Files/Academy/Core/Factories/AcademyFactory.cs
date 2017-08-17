using Academy.Core.Contracts;
using Academy.Core.Providers;
using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Resource;
using Academy.Models.Utils.Contracts;
using System;
using System.Linq;

namespace Academy.Core.Factories
{
    public class AcademyFactory : IAcademyFactory
    {
        private static IAcademyFactory instanceHolder = new AcademyFactory();

        // private because of Singleton design pattern
        private AcademyFactory()
        {
        }

        public static IAcademyFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }

        public ISeason CreateSeason(string startingYear, string endingYear, string initiative)
        {
            var parsedStartingYear = int.Parse(startingYear);
            var parsedEngingYear = int.Parse(endingYear);

            Initiative parsedInitiativeAsEnum;
            Enum.TryParse<Initiative>(initiative, out parsedInitiativeAsEnum);

            return new Season(parsedStartingYear, parsedEngingYear, parsedInitiativeAsEnum);
        }

        public IStudent CreateStudent(string username, string track)
        {
            Track parsedEnum;

            if (Enum.TryParse<Track>(track, out parsedEnum))
            {
                return new Student(username, parsedEnum);

            }
            throw new ArgumentException("The provided track is not valid!");
        }

        public ITrainer CreateTrainer(string username, string technologies)
        {
            var parsedTechnologies = technologies.Split(',').ToList();
            return new Trainer(username, parsedTechnologies);
        }

        public ICourse CreateCourse(string name, string lecturesPerWeek, string startingDate)
        {
            var parsedLectursPerWeek = int.Parse(lecturesPerWeek);
            var parsedStartingDate = DateTime.Parse(startingDate);
            return new Course(name, parsedLectursPerWeek, parsedStartingDate);
        }

        public ILecture CreateLecture(string name, string date, ITrainer trainer)
        {
            DateTime parsedDate = DateTime.Parse(date);
            return new Lecture(name, parsedDate, trainer);
        }

        public ILectureResource CreateLectureResource(string type, string name, string url)
        {
            
            var currentDate = DateTimeProvider.Now;

            switch (type.ToLower())
            {
                case "video":
                    return new VideoResource(name, url, ResourceType.Video, currentDate);
                case "presentation":
                    return new PresentationResource(name, url, ResourceType.Presentation);
                case "demo":
                    return new DemoResourcecs(name, url, ResourceType.Demo);
                case "homework":
                    return new HomeworkResource(name, url, ResourceType.Homework, currentDate);
                default: throw new ArgumentException("Invalid lecture resource type");
            }
        }

        public ICourseResult CreateCourseResult(ICourse course, string examPoints, string coursePoints)
        {
            var parsedExamPoints = float.Parse(examPoints);
            var parsedCoursePoints = float.Parse(coursePoints);
            return new CourseResult(course, parsedExamPoints, parsedCoursePoints);
        }
    }
}
