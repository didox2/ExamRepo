using System.Collections.Generic;
using Traveller.Commands.Contracts;

namespace Traveller.Core.Contracts
{
    public interface IParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}
