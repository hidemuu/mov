using Moq;
using Mov.Authorizers.Accounts;
using Mov.Authorizers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Mov.Commons.Test.Layouts.Builders;
using Mov.Layouts.Contexts;
using Mov.Schemas.Layouts.Styles;

namespace Mov.Commons.Test.Layouts
{
    public class LayoutTest
    {
        #region 定数

        private const string TEST_NAME = "LayoutTest";

        #endregion 定数

        #region フィールド

        private LayoutEngineBuilder builder;

        #endregion フィールド

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
            Assert.AreEqual(0, node.Children.Count);
        }

    }
}
