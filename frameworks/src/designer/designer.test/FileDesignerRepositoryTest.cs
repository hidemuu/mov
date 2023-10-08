using Mov.Core.Accessors.Models;
using Mov.Designer.Repository;
using Mov.Designer.Test.Builders;
using NUnit.Framework;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Designer.Test
{
    public class FileDesignerRepositoryTest
    {
        #region constants

        private const string TEST_NAME = "DesignertRepositoryTest";

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
        public void GetAsync_DeserializeContent_Return()
        {
            //Arrange
            var sut = new FileDesignerRepository(PathValue.Factory.CreateResourceRootPath().Value, FileType.Xml, EncodingValue.UTF8);

            //Act
            var contents = Task.WhenAll(sut.Contents.GetAsync()).Result[0].ToArray();

            //Assert
            Assert.That(contents.Length, Is.EqualTo(1));
            //var ex = Assert.Throws<InputException>(() => sut.GetLevels());
            //ex.Message.IsNormalized();
        }

        #endregion test
    }
}