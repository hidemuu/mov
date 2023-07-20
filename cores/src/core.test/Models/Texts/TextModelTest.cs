using Mov.Core.Models.Styles;
using Mov.Core.Models.Texts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.Test.Models.Texts
{
    [TestFixture]
    public class TextModelTest
    {
        #region constant

        private const string TEST_NAME = "TextModelTest";

        #endregion constant

        #region setup

        [OneTimeSetUp]
        public void ClassInitialize()
        {
            Trace.WriteLine(string.Join(' ', TEST_NAME, "ClassInitialize"));
        }

        [SetUp]
        public void Setup()
        {
            Trace.WriteLine(string.Join(' ', TEST_NAME, "TestInitialize"));
        }

        [TearDown]
        public void TestCleanup()
        {
            Trace.WriteLine(string.Join(' ', TEST_NAME, "TestCleanup"));
        }

        [OneTimeTearDown]
        public static void ClassCleanup()
        {
            Trace.WriteLine(string.Join(' ', TEST_NAME, "ClassCleanup"));
        }

        #endregion setup

        #region test

        [Test]
        public void EncodingValue_CreateEmpty_IsEmpty()
        {
            //Arrange
            var sut = EncodingValue.Empty;

            //Act
            //var node = sut.GetRegionNode(RegionStyle.Center);

            //Assert
            //Assert.AreEqual(0, node.Children.Count);
        }

        [Test]
        public void FileType_Initialized_XML()
        {
            //Arrange Act
            var sut = new FileType("xml");

            //Assert
            Assert.That(sut.IsXml(), Is.EqualTo(true));
            Assert.That(!sut.IsNan(), Is.EqualTo(true));
        }

        [Test]
        public void FileValue_CreateDir_IsDir()
        {
            //Arrange Act
            var sut = new FileValue(@"test/test1");

            //Assert
            Assert.That(sut.IsDir(), Is.EqualTo(true));
            Assert.That(sut.DirName, Is.EqualTo("test1"));
        }

        #endregion test
    }
}
