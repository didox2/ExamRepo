using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Commands.Creating;
using Traveller.Core.Contracts;
using Traveller.Core.Providers;
using Traveller.Models.Abstractions;

namespace Traveller.UnitTests.Commands.Creating.CreateTicketCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        private const string SuccessMessageTemplate =
            "Vehicle with ID {0} was created.";

        [TestMethod]
        public void CreateTicketAndAddItToDatabase_WhenParametersAreCorrect()
        {
            // Arrange
            var databaseMock = new Mock<IDatabase>();
            var factoryMock = new Mock<ITravellerFactory>();
            var firstTicketMock = new Mock<ITicket>();
            var secondTicketMock = new Mock<ITicket>();

            List<ITicket> tickets = new List<ITicket>();


            databaseMock.SetupGet(e => e.Tickets).Returns(new List<ITicket>());

            


            string result = string.Format(SuccessMessageTemplate, 0);

            CreateJourneyCommand command =
               new CreateJourneyCommand(databaseMock.Object., databaseMock.Object);



            List<string> parameters = new List<string>();


            string result = string.Format(SuccessMessageTemplate, 0);
            CreateTicketCommand command =
                new CreateTicketCommand(factoryMock.Object, databaseMock.Object);

            // Act
            string actualResult = command.Execute(parameters);

            // Assert
            Assert.AreEqual(result, actualResult);
        }

    }
}
