using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;
using System;
using System.Collections.Generic;

namespace OlympicGames.Core.Commands
{
    public class CreateSprinterCommand : Command
    {
        private readonly IDictionary<string, double> records;
        private readonly ISprinter sprinter;
        private Dictionary<string, double> temp = new Dictionary<string, double>();

        public CreateSprinterCommand(IList<string> commandLine) : base(commandLine)
        {
            if (commandLine.Count > 3)
            {
                string[] record;

                for (int i = 3; i < commandLine.Count; i++)
                {
                    record = commandLine[i].Split('/');
                    temp.Add(record[0], double.Parse(record[1]));
                }
                records = temp;
                this.sprinter = (ISprinter)this.Factory.CreateSprinter(commandLine[0], commandLine[1], commandLine[2], records);
            }
            else if (commandLine.Count < 3)
            {
                throw new ArgumentException(GlobalConstants.ParametersCountInvalid);
            }
            else
            {
                this.sprinter = (ISprinter)this.Factory.CreateSprinter(commandLine[0], commandLine[1], commandLine[2], null);
            }
            this.Committee.Olympians.Add(sprinter);
        }

        public override string Execute()
        {
            string result = "Created Sprinter\n" + this.sprinter.ToString();
            return result;
        }
    }
}
