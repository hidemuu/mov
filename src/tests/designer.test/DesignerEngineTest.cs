using Mov.Designer.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Mov.Designer.Test
{
    public class DesignertEngineTest
    {
        private DesignerEngineBuilder builder;

        [OneTimeSetUp]
        public void ClassInitialize()
        {
            this.builder = new DesignerEngineBuilder();
            Trace.WriteLine("UnitTest1 ClassInitialize");
        }

        [SetUp]
        public void Setup()
        {
            
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
            var sut = builder
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