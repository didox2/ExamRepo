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
            this.Committee.Olympians.Add(this.Factory.CreateSprinter(commandLine[0],commandLine[1],commandLine[2],new Dictionary<string,double>()));
        }

        public override string Execute()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("Created Sprinter\n");
            foreach (var item in this.Committee.Olympians)
            {
                if (this.Committee.Olympians.GetType().ToString()=="Sprinter")
                {
                    stringBuilder.Append(item);
                }
                
            }
            return stringBuilder.ToString();
        }
    }
}
