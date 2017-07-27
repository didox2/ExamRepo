using System;
using System.Collections.Generic;

using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;
using OlympicGames.Core.Commands.Abstracts;
using System.Text;

namespace OlympicGames.Core.Commands
{
    public class CreateBoxerCommand : Command, ICommand
    {
        public CreateBoxerCommand(IList<string> commandLine) : base(commandLine)
        {
            this.Committee.Olympians.Add(this.Factory.CreateBoxer(commandLine[0], commandLine[1], commandLine[2], 
                commandLine[3], int.Parse(commandLine[4]), int.Parse(commandLine[5])));
        }

        public override string Execute()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("Created Boxer\n");
            foreach (var item in this.Committee.Olympians)
            {
                stringBuilder.Append(item);
            }

            return stringBuilder.ToString();
        }
    }
}
