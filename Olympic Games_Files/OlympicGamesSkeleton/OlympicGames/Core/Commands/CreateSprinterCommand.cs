using System.Collections.Generic;

using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;
using OlympicGames.Core.Commands.Abstracts;
using System;
using System.Text;
using System.Collections.Generic;

namespace OlympicGames.Core.Commands
{
    public class CreateSprinterCommand : Command, ICommand
    {
        // Consider using the dictionary
        private readonly IDictionary<string, double> records;

        public CreateSprinterCommand(IList<string> commandLine) : base(commandLine)
        {
            if (commandLine.Count > 3)
            {
                string[] record;
                for (int i = 3; i < commandLine.Count; i++)
                {
                    record = commandLine[i].Split('/');
                    records.Add(record[0], double.Parse(record[1]));
                }

            }

            this.Committee.Olympians.Add(this.Factory.CreateSprinter(commandLine[0], commandLine[1], commandLine[2], records));
        }

        public override string Execute()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("Created Sprinter\n");
            foreach (var item in this.Committee.Olympians)
            {
                stringBuilder.Append(item);
            }
            return stringBuilder.ToString();
        }
    }
}
