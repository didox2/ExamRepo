using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Traveller.Commands.Creating;
using Traveller.Core.Contracts;
using Traveller.Core.Providers;
using Traveller.Models.Abstractions;
using Traveller.Models.Vehicles.Abstractions;

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
            var journeyMock = new Mock<IJourney>();

            var busVehicleMock = new Mock<IVehicle>();
            var ticketMock = new Mock<ITicket>();

            journeyMock.Setup(m => m.Vehicle).Returns(busVehicleMock.Object);
            
            List<ITicket> tickets = new List<ITicket>();
            tickets.Add(ticketMock.Object);

            ticketMock.Setup(m => m.Journey).Returns(journeyMock.Object);
            
            databaseMock.SetupGet(e => e.Tickets).Returns(tickets);
            factoryMock.Setup(m => m.CreateTicket(journeyMock.Object, 10m)).Returns(ticketMock.Object);

            List<string> parameters = new List<string>()
            {
                "0",
                "15"
            };

            CreateTicketCommand command = new CreateTicketCommand(factoryMock.Object, databaseMock.Object);

            // Act
            command.Execute(parameters);

            // Assert
            Assert.AreEqual(1, databaseMock.Object.Journeys.Count);
            Assert.AreSame(ticketMock.Object, databaseMock.Object.Tickets.Single());
        }

    }
}
