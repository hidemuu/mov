using Mov.Designer.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Mov.Designer.Test
{
    public class DesignertEngineTest
    {
        #region �萔

        private const string TEST_NAME = "DesignertEngineTest";

        #endregion �萔

        #region �t�B�[���h

        private DesignerEngineBuilder builder;

        #endregion �t�B�[���h

        [OneTimeSetUp]
        public void ClassInitialize()
        {
            this.builder = new DesignerEngineBuilder();
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

        /// <summary>
        /// �R���e���c�擾�V�i���I
        /// </summary>
        [Test]
        public void GetContent()
        {
            //Arrange
            var sut = this.builder
                .WithContentCalled(new List<LayoutContent>())
                .WithNodeCalled(new List<LayoutNode>())
                .Build();

            //Act
            var contents = sut.Repository.Contents.Get();
           
            //Assert
            //Assert.Pass();
            Assert.AreEqual(0, contents.Count(), "");
        }
    }
}