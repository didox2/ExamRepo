using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Traveller.Commands.Creating;
using Traveller.Models.Abstractions;

namespace Traveller.UnitTests.Commands.Creating.CreateTicketCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowExceptions_WhenParametersAreNull()
        {
            //Arrange
            var createTicketMock = new Mock<ITicket>();
            //Act && Assert

            Assert.ThrowsException<ArgumentNullException>(() => new CreateTicketCommand(null, null), null);
        }
    }
}
