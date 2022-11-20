using Moq;
using Mov.Game.Models;
using Mov.Game.Service;
using NUnit.Framework;

namespace Mov.Game.Test
{
    public class GameServiceTest
    {
        private Mock<IFiniteStateMachineGameEngine> mockEngine;

        [SetUp]
        public void Setup()
        {
            mockEngine = new Mock<IFiniteStateMachineGameEngine>();
        }

        [Test]
        public void Test1()
        {
            //Arrange
            //var sut = new GraphicGameService();

            //Act

            //Assert
            Assert.Pass();
            //Assert.AreEqual();
        }
    }
}