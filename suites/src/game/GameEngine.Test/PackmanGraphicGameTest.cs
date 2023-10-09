using Mov.Core.Accessors.Models;
using Mov.Framework.Services;
using Mov.Game.Repository;
using Mov.Suite.GameClient.FiniteStateMechine;
using Mov.Suite.GameEngine.Graphic;
using System.Diagnostics;

namespace GameEngine.Test
{
    public class PackmanGraphicGameTest
    {
        #region constants

        private const string TEST_NAME = nameof(PackmanGraphicGameTest);

        #endregion constants

        #region field

        #endregion field

        #region setup

        [OneTimeSetUp]
        public void ClassInitialize()
        {
            Trace.WriteLine($"{TEST_NAME} ClassInitialize");
        }

        [SetUp]
        public void Setup()
        {
            Trace.WriteLine($"{TEST_NAME} TestInitialize");
        }

        [TearDown]
        public void TestCleanup()
        {
            Trace.WriteLine($"{TEST_NAME} TestCleanup");
        }

        [OneTimeTearDown]
        public static void ClassCleanup()
        {
            Trace.WriteLine($"{TEST_NAME} ClassCleanup");
        }

        #endregion setup

        #region test

        [Test]
        public void GetLevel()
        {
            //Arrange
            var path = Path.Combine(PathCreator.GetResourcePath(), "game");
            var repository = new FileGameRepository(path, FileType.Json, EncodingValue.UTF8);
            var client = new FiniteStateMachineGameClient(repository);
            var sut = new PackmanGraphicGame(client);

            //Act
            var level = sut.Level;

            //Assert
            Assert.That(level, Is.EqualTo(1));
        }

        [Test]
        public void InitializeController()
        {
            //Arrange
            var path = Path.Combine(PathCreator.GetResourcePath(), "game");
            var repository = new FileGameRepository(path, FileType.Json, EncodingValue.UTF8);
            var client = new FiniteStateMachineGameClient(repository);
            var sut = new PackmanGraphicGame(client);

            //Act
            var controller = sut.GraphicController;
            controller.Initialize();

            //Assert
            Assert.That(sut.Level, Is.EqualTo(1));
        }

        #endregion test
    }
}