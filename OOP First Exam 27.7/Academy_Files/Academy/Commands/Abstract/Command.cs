using System.Collections.Generic;
using Academy.Commands.Contracts;
using Academy.Core.Contracts;

namespace Academy.Commands.Abstract
{
    public abstract class Command : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IEngine engine;

        protected Command(IAcademyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public IAcademyFactory Factory
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
