using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Creating.Abstract
{
    public abstract class CreateCommand : ICommand
    {
        private readonly ITravellerFactory factory;
        private readonly IEngine engine;


        protected CreateCommand(ITravellerFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public int PassengerCapacity { get;}

        public decimal PricePerKilometer { get; }

        public ITravellerFactory Factory
        {
            get
            {
                return this.factory;
            }
        }

        public IEngine Engine
        {
            get
            {
                return this.engine;
            }
        }

        public abstract string Execute(IList<string> parameters);

    }
}
