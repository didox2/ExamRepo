using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;
using System;
using System.Collections.Generic;

namespace OlympicGames.Core.Commands.Abstracts
{
    public abstract class CreateOlympianCommand : Command
    {
        protected readonly string firstName;
        protected readonly string lastName;
        protected readonly string country;
        private IOlympian olympian;

        public CreateOlympianCommand(IList<string> commandLine) : base(commandLine)
        {
            if (commandLine.Count < 3)
            {
                throw new ArgumentException(GlobalConstants.ParametersCountInvalid);
            }

            this.firstName = commandLine[0];
            this.lastName = commandLine[1];
            this.country = commandLine[2];
        }

        public abstract IOlympian CreateOlympian();

        public override string Execute()
        {
            this.olympian = this.CreateOlympian();
            this.Committee.Olympians.Add(this.olympian);
            return string.Format($"Created {this.olympian.GetType().Name}\n{this.olympian}");
        }
    }
}
