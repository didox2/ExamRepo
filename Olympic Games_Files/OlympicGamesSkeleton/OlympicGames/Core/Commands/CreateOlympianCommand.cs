//using OlympicGames.Core.Commands.Abstracts;
//using OlympicGames.Olympics.Contracts;
//using OlympicGames.Utils;
//using System;
//using System.Collections.Generic;

//namespace OlympicGames.Core.Commands
//{
//    public abstract class CreateOlympianCommand : Command
//    {
//        private IOlympian olympian;

//        public CreateOlympianCommand(IList<string> commandLine) : base(commandLine)
//        {
//            if (commandLine.Count < 3)
//            {
//                throw new ArgumentException(GlobalConstants.ParametersCountInvalid);
//            }
//            else
//            {
//                this.olympian = (IOlympian)this.Factory.CreatePerson(commandLine[0], commandLine[1], commandLine[2]);
//            }
//        }

//        public override string Execute()
//        {
//            return null;
//        }
//    }
//}
