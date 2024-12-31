using Mov.Core.Accessors.Models;

namespace Mov.Core.Accessors.Test
{
    [TestFixture]
    public class PathValueTest
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
            var sut = PathValue.Factory.CreateSolutionRootPath("mov");

            //Assert
            Assert.That(sut.IsDir());
            Assert.That(!sut.IsEmpty());
            Assert.That(sut.IsRooted());
            Assert.That(sut.DirPath.Contains("mov"));
        }

        [Test]
        public void CreateResource_SolutionRoot_ReturnEndpointPath()
        {
            //Arrange & Act
            var sut = PathValue.Factory.CreateResourceRootPath("mov");

            //Assert
            Assert.That(sut.IsDir());
            Assert.That(!sut.IsEmpty());
            Assert.That(sut.IsRooted());
            Assert.That(sut.DirPath.Contains("resource"));
        }

        [Test]
        public void CreateAssembly_SolutionRoot_ReturnEndpointPath()
        {
            //Arrange & Act
            var sut = PathValue.Factory.CreateAssemblyRootPath();

            //Assert
            Assert.That(sut.IsDir());
            Assert.That(!sut.IsEmpty());
            Assert.That(sut.IsRooted());
        }
    }
}
