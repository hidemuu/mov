using Mov.Core.Layouts.Models.Nodes;
using Mov.Core.Layouts.Test.Builders;
using Mov.Core.Models.ValueObjects.Layouts;
using System.Diagnostics;

namespace Mov.Core.Layouts.Test
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
            builder = new LayoutEngineBuilder();
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
            var sut = builder
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