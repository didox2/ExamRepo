using System;
using System.Collections.Generic;

using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;
using OlympicGames.Core.Commands.Abstracts;

namespace OlympicGames.Core.Commands
{
    public class CreateBoxerCommand : Command, ICommand
    {
        public CreateBoxerCommand(IList<string> commandLine) : base(commandLine)
        {
            
        }

        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
