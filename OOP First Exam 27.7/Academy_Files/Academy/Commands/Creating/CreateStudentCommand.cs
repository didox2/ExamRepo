using Academy.Commands.Abstract;
using Academy.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Commands.Creating
{
    public class CreateStudentCommand : Command
    {
        public CreateStudentCommand(IAcademyFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var username = parameters[0];
            var track = parameters[1];

            if (this.Engine.Students.Any(x => x.Username.ToLower() == username.ToLower()) ||
                this.Engine.Trainers.Any(x => x.Username.ToLower() == username.ToLower()))
            {
                throw new ArgumentException($"A user with the username {username} already exists!");
            }

            var student = this.Factory.CreateStudent(username, track);
            this.Engine.Students.Add(student);

            return $"Student with ID {this.Engine.Students.Count - 1} was created.";
        }
    }
}
