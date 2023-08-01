using Mov.Core.Models.Connections;
using Mov.Core.Models.Texts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.Test.Models.Connections
{
    [TestFixture]
    public class PathModelTest
    {
        [Test]
        public void CreateEmpty_IsEmpty_ReturnEmptyPath()
        {
            //Arrange & Act
            var sut = PathValue.Empty;

            //Assert
            Assert.That(sut.IsEmpty());            
        }

        [Test]
        public void CreateSolution_SolutionRoot_ReturnEndpointPath()
        {
            //Arrange & Act
            var sut = PathValue.Factory.CreateSolutionPath("mov");

            //Assert
            Assert.That(sut.IsDir());
            Assert.That(!sut.IsEmpty());
            Assert.That(sut.IsRooted());
            Assert.That(sut.DirPath.Contains("mov"));
        }
    }
}
