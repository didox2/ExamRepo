using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Models;
using System;
using System.Collections.Generic;

namespace Academy.Commands.Listing
{
    public class ListUsersCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IEngine engine;

        public ListUsersCommand(IAcademyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }
        public string Execute(IList<string> parameters)
        {
            if (this.engine.Students.Count == 0 && this.engine.Trainers.Count == 0)
            {
                throw new ArgumentException("There are no registered users!");
            }

            List<IUser> users = new List<IUser>();
            
            for (int i = 0; i < this.engine.Trainers.Count; i++)
            {
                users.Add(this.engine.Trainers[i]);
            }
            for (int i = 0; i < this.engine.Students.Count; i++)
            {
                users.Add(this.engine.Students[i]);
            }
            
            return string.Join("\n", users);
        }
    }
}
