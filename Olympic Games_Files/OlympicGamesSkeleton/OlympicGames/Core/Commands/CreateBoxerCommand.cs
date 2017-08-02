using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;
using System;
using System.Collections.Generic;

namespace OlympicGames.Core.Commands
{
    public class CreateBoxerCommand : Command
    {
        private IBoxer boxer;
        private int wins;
        private int losses;

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
                if (winsAreNumber && lossesAreNumber)
                {
                    this.boxer = (IBoxer)this.Factory.CreateBoxer(commandLine[0], commandLine[1], commandLine[2], commandLine[3], 
                        int.Parse(commandLine[4]), int.Parse(commandLine[5]));
                    this.Committee.Olympians.Add(boxer);
                }
                else
                {
                    throw new ArgumentException(GlobalConstants.WinsLossesMustBeNumbers);
                }
            }
        }

        public override string Execute()
        {
            string result = "Created Boxer\n" + this.boxer.ToString();
            return result;
        }
    }
}
