using Moq;
using Mov.Game.Models;
using Mov.Game.Service;
using Mov.Utilities.Exceptions;
using NUnit.Framework;
using System.Diagnostics;

namespace Mov.Game.Test
{
    public class GameServiceTest
    {
        private GameServiceBuilder builder;

        [OneTimeSetUp]
        public void ClassInitialize()
        {
            Trace.WriteLine("UnitTest1 ClassInitialize");
        }

        [SetUp]
        public void Setup()
        {
            builder = new GameServiceBuilder();
            Trace.WriteLine("UnitTest1 TestInitialize");
        }

        [TearDown]
        public void TestCleanup()
        {
            Trace.WriteLine("UnitTest1 TestCleanup");
        }

        [OneTimeTearDown]
        public static void ClassCleanup()
        {
            Trace.WriteLine("UnitTest1 ClassCleanup");
        }

        [Test]
        public void Test1()
        {
            //Arrange
            var sut = builder.WithEngineCalled().Build();

            //Act
            var level = sut.GetLevels();

            //Assert
            //Assert.Pass();
            Assert.AreEqual(0, level, "");
            //var ex = Assert.Throws<InputException>(() => sut.GetLevels());
            //ex.Message.IsNormalized();
        }
    }
}