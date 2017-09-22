using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;

namespace Traveller.UnitTests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class ParseCommand_Should
    {
        [TestMethod]
        public void ReturnCommandAsAString_WhenParametersAreCorrect()
        {
            //Arrange
            
            string fullCommand = "createbus 10 0.7";
            var expectedResult = "createbus";

            var commandParser = new Mock<ICommandParser>();
            var commandFactory = new Mock<ICommandFactory>();
            var command = new Mock<ICommand>();

            commandParser.Setup(m => m.ParseCommand(fullCommand)).Returns(commandFactory.Object.GetCommand(expectedResult));
            commandFactory.Setup(m => m.GetCommand(fullCommand)).Returns(command.Object);
            
            //Act
            commandParser.Object.ParseCommand(fullCommand);

            //Assert
            Assert.AreEqual(expectedResult, commandFactory.Object.GetCommand(fullCommand).ToString());
        }

    }
}
