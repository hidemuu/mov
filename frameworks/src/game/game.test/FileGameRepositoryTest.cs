using Mov.Core.Accessors.Models;
using Mov.Game.Repository;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Game.Test
{
    public class FileGameRepositoryTest
    {
        #region constants

        private const string TEST_NAME = nameof(FileGameRepositoryTest);

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
        public void GetAsync_DeserializeContent_Return()
        {
            //Arrange
            var resourcePath = PathValue.Factory.CreateResourceRootPath().Value;
            var sut = new FileGameRepository(resourcePath, FileType.Json, EncodingValue.UTF8);

            //Act
            var landmarks = Task.WhenAll(sut.Landmarks.GetsAsync()).Result[0].ToArray();

            //Assert
            Assert.That(landmarks.Length, Is.EqualTo(3));
            //var ex = Assert.Throws<InputException>(() => sut.GetLevels());
            //ex.Message.IsNormalized();
        }
    }
}