using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Olympics.Contracts;
using System.Collections.Generic;

namespace OlympicGames.Core.Commands
{
    public class CreateSprinterCommand : CreateOlympianCommand
    {
        private readonly IDictionary<string, double> records;
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
                this.records = temp;
            }
        }

        public override IOlympian CreateOlympian()
        {
            return this.Factory.CreateSprinter(this.firstName, this.lastName, this.country, this.records);
        }
    }
}
