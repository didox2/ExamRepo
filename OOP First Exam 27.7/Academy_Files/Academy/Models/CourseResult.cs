using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Utils.Contracts;
using System;

namespace Academy.Models
{
    public class CourseResult : ICourseResult
    {
        private float examPoints;
        private float coursePoints;
        private Grade grade;
        private ICourse course;

        public CourseResult(ICourse course, float examPoints, float coursePoints)
        {
            this.Course = course;
            this.ExamPoints = examPoints;
            this.CoursePoints = coursePoints;
        }

        public ICourse Course
        {
            get
            {
                return this.course;
            }
            set
            {
                this.course = value;
            }
        }

        public float ExamPoints
        {
            get
            {
                return this.examPoints;
            }
            set
            {
                if (value < 0 || value > 1000)
                {
                    throw new ArgumentException("Course result's exam points should be between 0 and 1000!");

                }
                this.examPoints = value;
            }
        }

        public float CoursePoints
        {
            get
            {
                return this.coursePoints;
            }
            set
            {
                if (value < 0 || value > 125)
                {
                    throw new ArgumentException("Course result's course points should be between 0 and 125!");

                }
                this.coursePoints = value;
            }
        }

        public Grade Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                if (ExamPoints >= 65 || CoursePoints >= 75)
                {
                    this.grade = Grade.Excellent;
                }
                else if ((ExamPoints < 65 && ExamPoints >= 30) || (CoursePoints >= 45 && CoursePoints < 75))
                {
                    this.grade = Grade.Passed;
                }
                else
                {
                    this.grade = Grade.Failed;
                }
            }
        }
        public override string ToString()
        {
            return "  * " + this.Course.Name + ": Points - " + this.CoursePoints + ", Grade - " + this.Grade;
        }
    }
}
