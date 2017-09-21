using Ninject.Modules;
using Traveller.Commands.Contracts;
using Traveller.Commands.Creating;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;
using Traveller.Core.Providers;

namespace Traveller.Ninject
{
    public class TravellerModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IEngine>().To<Engine>().InSingletonScope();
            this.Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();

            this.Bind<ITravellerFactory>().To<TravellerFactory>().InSingletonScope();
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();
            this.Bind<ICommandParser>().To<CommandParser>().InSingletonScope();
            this.Bind<ICommandProcessor>().To<CommandProcessor>().InSingletonScope();
            this.Bind<IDatabase>().To<Database>().InSingletonScope();

            this.Bind<ICommand>().To<CreateAirplaneCommand>().Named("CreateAirplaneInternal");
            this.Bind<ICommand>().To<CreateBusCommand>().Named("CreateBusInternal");
            this.Bind<ICommand>().To<CreateJourneyCommand>().Named("CreateJourneyInternal");
            this.Bind<ICommand>().To<CreateTicketCommand>().Named("CreateTicketInternal");
            this.Bind<ICommand>().To<CreateTrainCommand>().Named("CreateTrainInternal");

            this.Bind<ICommand>().To<ListJourneysCommand>().Named("ListJourneysInternal");
            this.Bind<ICommand>().To<ListTicketsCommand>().Named("ListTicketsInternal");
            this.Bind<ICommand>().To<ListVehiclesCommand>().Named("ListVehiclesCommandInternal");

        }
    }
}
