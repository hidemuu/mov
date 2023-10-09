using Mov.Suite.GameClient.FiniteStateMechine;
using Mov.Suite.GameClient.Test.Builders;
using System.Diagnostics;

namespace Mov.Suite.GameClient.Test
{
    public class FiniteStateMachineTest
    {
        #region constants

        private const string TEST_NAME = nameof(FiniteStateMachineTest);

        #endregion constants

        #region field

        private GameRepositoryBuilder _repositoryBuilder;

        #endregion field

        #region setup

        [OneTimeSetUp]
        public void ClassInitialize()
        {
            _repositoryBuilder = new GameRepositoryBuilder();
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

        [Test]
        public void GetLandmark()
        {
            //Arrange
            var repository = _repositoryBuilder.Build();
            var sut = new FiniteStateMachineGameClient(repository);

            //Act
            var landmark = sut.GetLandmark();

            //Assert
            Assert.That(landmark.Lv, Is.EqualTo(1));
        }
    }
}