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
        public void Encode_Initialized()
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
            //Arrange
            var sut = FileType.Xml;

            //Act
            var isXml = sut.IsXml();
            var isNan = sut.IsNan();

            //Assert
            Assert.That(isXml, Is.EqualTo(true));
            Assert.That(!isNan, Is.EqualTo(true));
        }

        [Test]
        public void FileValue_Create()
        {
            //Arrange
            var sut = new FileValue("test");

            //Act

            //Assert
            Assert.That(sut.IsDir(), Is.EqualTo(true));

        }

        #endregion test
    }
}
