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
    public class ConnectionModelTest
    {
        [Test]
        public void PathValue_CreateEmpty_IsEmpty()
        {
            //Arrange & Act
            var sut = PathValue.Empty;

            //Assert
            Assert.That(sut.Value.Equals(""));            
        }
    }
}
