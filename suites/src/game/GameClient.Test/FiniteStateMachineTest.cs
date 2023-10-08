using System.Diagnostics;

namespace Mov.Suite.GameClient.Test
{
    public class FiniteStateMachineTest
    {
        #region constants

        private const string TEST_NAME = nameof(FiniteStateMachineTest);

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

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}