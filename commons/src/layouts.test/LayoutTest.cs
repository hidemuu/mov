using Mov.Commons.Test.Layouts.Builders;
using Mov.Layouts.Models.Nodes.Entities;
using Mov.Layouts.Models.Shells.ValueObjects;
using System.Diagnostics;

namespace Mov.Commons.Test.Layouts
{
    public class LayoutTest
    {
        #region constant

        private const string TEST_NAME = "LayoutTest";

        #endregion constant

        #region field

        private LayoutEngineBuilder builder;

        #endregion field

        #region setup

        [OneTimeSetUp]
        public void ClassInitialize()
        {
            this.builder = new LayoutEngineBuilder();
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
        public void GetCenterRegionNode()
        {
            //Arrange
            var sut = this.builder
                .WithNodeCalled(new List<LayoutNode> { LayoutNode.Empty })
                .Build();

            //Act
            var node = sut.GetRegionNode(RegionStyle.Center);

            //Assert
            //Assert.AreEqual(0, node.Children.Count);
        }

        #endregion test
    }
}