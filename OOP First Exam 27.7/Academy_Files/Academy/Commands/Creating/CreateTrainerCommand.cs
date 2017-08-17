using Academy.Commands.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using Academy.Core.Contracts;

namespace Academy.Commands.Creating
{
    public class CreateTrainerCommand : Command
    {
        public CreateTrainerCommand(IAcademyFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var username = parameters[0];
            var technologies = parameters[1];

            if (this.Engine.Students.Any(x => x.Username.ToLower() == username.ToLower()) ||
                this.Engine.Trainers.Any(x => x.Username.ToLower() == username.ToLower()))
            {
                throw new ArgumentException($"A user with the username {username} already exists!");
            }

            var trainer = this.Factory.CreateTrainer(username, technologies);
            this.Engine.Trainers.Add(trainer);

            return $"Trainer with ID {this.Engine.Trainers.Count - 1} was created.";
        }
    }
}
