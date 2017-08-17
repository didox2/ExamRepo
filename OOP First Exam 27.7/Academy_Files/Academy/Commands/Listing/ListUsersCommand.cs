using Academy.Commands.Abstract;
using Academy.Models;
using System;
using System.Collections.Generic;
using Academy.Core.Contracts;

namespace Academy.Commands.Listing
{
    public class ListUsersCommand : Command
    {
        public ListUsersCommand(IAcademyFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            if (this.Engine.Students.Count == 0 && this.Engine.Trainers.Count == 0)
            {
                throw new ArgumentException("There are no registered users!");
            }

            List<IUser> users = new List<IUser>();
            
            for (int i = 0; i < this.Engine.Trainers.Count; i++)
            {
                users.Add(this.Engine.Trainers[i]);
            }
            for (int i = 0; i < this.Engine.Students.Count; i++)
            {
                users.Add(this.Engine.Students[i]);
            }
            
            return string.Join("\n", users);
        }
    }
}
