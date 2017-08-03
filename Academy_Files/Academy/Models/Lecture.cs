using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class Lecture : ILecture
    {
        public Lecture(string name, DateTime date, ITrainer trainer)
        {
            
        }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime Date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ITrainer Trainer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IList<ILectureResource> Resources => throw new NotImplementedException();
    }
}
