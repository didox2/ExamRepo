using System;
using System.Text;
using Traveller.Core.Contracts;

namespace Traveller.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandProcessor commandProcessor;

        private readonly StringBuilder builder = new StringBuilder();

        public Engine(IReader reader, IWriter writer, ICommandProcessor commandProcessor)
        {
            this.reader = reader ?? throw new ArgumentNullException("reader");
            this.writer = writer ?? throw new ArgumentNullException("writer");
            this.commandProcessor = commandProcessor ?? throw new ArgumentNullException("commandProcessor");
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    {
                        this.writer.Write(this.builder.ToString());
                        break;
                    }

                    this.commandProcessor.ProcessCommand(commandAsString, builder);
                }
                catch (Exception ex)
                {
                    this.builder.AppendLine(ex.Message);
                }
            }
        }
    }
}
