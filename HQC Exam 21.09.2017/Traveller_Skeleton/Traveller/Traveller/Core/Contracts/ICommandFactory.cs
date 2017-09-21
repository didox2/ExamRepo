using Traveller.Commands.Contracts;

namespace Traveller.Core.Contracts
{
    public interface ICommandFactory
    {
        ICommand GetCommand(string commandName);
    }
}
