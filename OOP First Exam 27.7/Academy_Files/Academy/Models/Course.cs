using Academy.Models.Contracts;
using System;
using System.Collections.Generic;

namespace Academy.Models
{
    public class Course : ICourse
    {
        private string name;
        private int lecturesPerWeek;
        private DateTime startingDate;
        private DateTime endingDate;
        private IList<ILecture> lectures;
        private IList<IStudent> onlineStudents;
        private IList<IStudent> onsiteStudents;

        public Course(string name, int lecturesPerWeek, DateTime startingDate)
        {
            this.Name = name;
            this.LecturesPerWeek = lecturesPerWeek;
            this.StartingDate = startingDate;
            this.EndingDate = startingDate.AddDays(30);
            this.Lectures = new List<ILecture>();
            this.OnlineStudents = new List<IStudent>();
            this.OnsiteStudents = new List<IStudent>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3 || value.Length > 45)
                {
                    throw new ArgumentException("The name of the course must be between 3 and 45 symbols!");
                }
                this.name = value;
            }
        }
        public int LecturesPerWeek
        {
            get
            {
                return this.lecturesPerWeek;
            }
            set
            {
                if (value < 1 || value > 7)
                {
                    throw new ArgumentException("The number of lectures per week must be between 1 and 7!");
                }
                this.lecturesPerWeek = value;
            }
        }
        public DateTime StartingDate
        {
            get
            {
                return this.startingDate;
            }
            set
            {
                this.startingDate = value;
            }
        }
        public DateTime EndingDate
        {
            get
            {
                return this.endingDate;
            }
            set
            {
                this.endingDate = value;
            }
        }

        public IList<IStudent> OnsiteStudents
        {
            get
            {
                return this.onsiteStudents;
            }
            set
            {

                this.onsiteStudents = value;
            }
        }

        public IList<IStudent> OnlineStudents
        {
            get
            {
                return this.onlineStudents;
            }
            set
            {
                this.onlineStudents = value;
            }
        }

        public IList<ILecture> Lectures
        {
            get
            {
                return this.lectures;
            }
            set
            {
                this.lectures = value;
            }
        }

        public override string ToString()
        {
            return $"* Course:\n - Name: {this.Name}\n - Lectures per week: {this.LecturesPerWeek}\n" +
            $" - Starting date: {this.StartingDate}\n - Ending date: {this.EndingDate}\n" +
            $" - Onsite students: {this.OnsiteStudents.Count}\n - Online students: {this.OnlineStudents.Count}\n - Lectures:\n" +
            (this.Lectures.Count != 0 ? string.Join("\n", this.Lectures) : "  * There are no lectures in this course!");
        }
    }
}
