using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;
using System;
using System.Collections.Generic;

namespace OlympicGames.Core.Commands
{
    public class CreateBoxerCommand : CreateOlympianCommand
    {
        private int wins;
        private int losses;
        private string category;

        public CreateBoxerCommand(IList<string> commandLine) : base(commandLine)
        {
            if (commandLine.Count < 5)
            {
                throw new ArgumentException(GlobalConstants.ParametersCountInvalid);
            }
            else
            {
                bool winsAreNumber = int.TryParse(commandLine[4], out wins);
                bool lossesAreNumber = int.TryParse(commandLine[5], out losses);

                if (!winsAreNumber || !lossesAreNumber)
                {
                    throw new ArgumentException(GlobalConstants.WinsLossesMustBeNumbers);
                }

                this.category = commandLine[3];
            }
        }
        public override IOlympian CreateOlympian()
        {
            return this.Factory.CreateBoxer(this.firstName, this.lastName, this.country, this.category, this.wins, this.losses);
        }
    }
}
