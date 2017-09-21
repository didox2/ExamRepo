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
            decimal administrativeCosts = 1.0m;
            var databaseMock = new Mock<IDatabase>();
            var factoryMock = new Mock<ITravellerFactory>();
            var journeyMock = new Mock<IJourney>();
            var busVehicleMock = new Mock<IVehicle>();
            var ticketMock = new Mock<ITicket>();
            var firstTicketMock = new Mock<ITicket>();
            var secondTicketMock = new Mock<ITicket>();
            List<ITicket> tickets = new List<ITicket>();
            tickets.Add(firstTicketMock.Object);
            tickets.Add(secondTicketMock.Object);
            

            databaseMock.SetupGet(e => e.Tickets).Returns(tickets);
            factoryMock.Setup(m => m.CreateBus(20, 2.0m)).Returns(busVehicleMock.Object);
            factoryMock.Setup(m => m.CreateJourney("Sofia", "London", 3000, busVehicleMock.Object));
            factoryMock.Setup(m => m.CreateTicket(journeyMock.Object, administrativeCosts)).Returns(ticketMock.Object);

            List<string> parameters = new List<string>()
            {
                "1",
                "30"
            };
            
            CreateTicketCommand command =
                new CreateTicketCommand(factoryMock.Object, databaseMock.Object);

            // Act
            command.Execute(parameters);

            // Assert
            Assert.AreEqual(1, databaseMock.Object.Journeys.Count -1);
            Assert.AreSame(ticketMock.Object, databaseMock.Object.Tickets.Single());
        }

    }
}
