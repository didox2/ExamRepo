using Academy.Models.Contracts;
using System;
using System.Collections.Generic;

namespace Academy.Models
{
    public class Lecture : ILecture
    {
        private string name;
        private DateTime date;
        private ITrainer trainer;
        private IList<ILectureResource> resources;

        public Lecture(string name, DateTime date, ITrainer trainer)
        {
            this.Name = name;
            this.Date = date;
            this.Trainer = trainer;
            this.Resources = new List<ILectureResource>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length < 5 || value.Length > 30)
                {
                    throw new ArgumentException("Lecture's name should be between 5 and 30 symbols long!");
                }
                this.name = value;
            }
        }
        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }
        public ITrainer Trainer
        {
            get
            {
                return this.trainer;
            }
            set
            {
                this.trainer = value;
            }
        }

        public IList<ILectureResource> Resources
        {
            get
            {
                return this.resources;
            }
            set
            {
                this.resources = value;
            }
        }
        public override string ToString()
        {
            return $"  * Lecture:\n   - Name: {this.Name}\n   - Date: {this.Date}\n   - Trainer username: {this.Trainer.Username}\n" +
            $"   - Resources:\n" + (this.Resources.Count != 0 ? string.Join("\n", this.Resources) : "    * There are no resources in this lecture.");
        }
    }
}
