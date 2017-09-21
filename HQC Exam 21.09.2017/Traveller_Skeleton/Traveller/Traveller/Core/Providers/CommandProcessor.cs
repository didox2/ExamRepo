using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Core.Contracts;

namespace Traveller.Core.Providers
{
    public class CommandProcessor : ICommandProcessor
    {
        private ICommandParser commandParser;

        public CommandProcessor(ICommandParser commandParser)
        {
            this.commandParser = commandParser ?? throw new ArgumentNullException("commandParser");

            this.commandParser = commandParser;
        }
        public void ProcessCommand(string commandAsString, StringBuilder builder)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }
            
            var command = this.commandParser.ParseCommand(commandAsString);
            var parameters = this.commandParser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            builder.AppendLine(executionResult);
        }
    }
}
