using Academy.Models.Enums;
using System;

namespace Academy.Models.Resource
{
    public class HomeworkResource : LectureResource
    {
        private DateTime dueDate;

        public HomeworkResource(string name, string url, ResourceType type, DateTime dueDate) : base(name, url, type)
        {
            this.DueDate = dueDate.AddDays(7);
        }

        public DateTime DueDate
        {
            get
            {
                return this.dueDate;
            }
            set
            {
                this.dueDate = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"\n     - Due date: {this.DueDate}";
        }
    }
}
