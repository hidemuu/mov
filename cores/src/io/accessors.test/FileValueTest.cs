﻿using Mov.Core.Accessors.Models;
using System.Diagnostics;

namespace Mov.Core.Accessors.Test
{
    [TestFixture]
    public class FileValueTest
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
            //Arrange & Act
            var sut = new FileType(".xml");

            //Assert
            Assert.That(sut.IsXml(), Is.EqualTo(true));
            Assert.That(!sut.IsNan(), Is.EqualTo(true));
        }

        [Test]
        public void FileValue_CreateDir_IsDir()
        {
            //Arrange & Act
            var sut = new FileValue(new PathValue(@"test/test1").Value);

            //Assert
            Assert.That(sut.DirName, Is.EqualTo("test1"));
        }

        #endregion test
    }
}
