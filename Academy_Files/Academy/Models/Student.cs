using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Utils.Contracts;
using System;
using System.Collections.Generic;

namespace Academy.Models
{
    public class Student : User, IStudent
    {
        private Track track;
        private IList<ICourseResult> courseResults;

        public Student(string username, Track track) : base(username)
        {
            this.Track = track;
            this.CourseResults = new List<ICourseResult>();
        }

        public Track Track
        {
            get
            {
                return this.track;
            }
            set
            {
                this.track = value;
            }
        }
        public IList<ICourseResult> CourseResults
        {
            get
            {
                return this.courseResults;
            }
            set
            {
                this.courseResults = value;
            }
        }
        
        public override string ToString()
        {
            return $"* Student:\n - Username: {base.Username}\n - Track: {this.Track}\n - Course results:\n" +
            (this.CourseResults.Count == 0 ? "  * User has no course results!" : string.Join("\n", this.CourseResults));
        }
    }
}
