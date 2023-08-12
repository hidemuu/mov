using Mov.Core.Repositories.Implements.DbObjects;
using Mov.Core.Repositories.Test.Builders;
using Mov.Core.Repositories.Test.Models;

namespace Mov.Core.Repositories.Test
{
    [TestFixture]
    public class DbObjectRepositoryTest
    {
        #region field

        private RepositorySerializerBuilder serializerBuilder;

        #endregion field

        [SetUp]
        public void Setup()
        {
            this.serializerBuilder = new RepositorySerializerBuilder();
        }

        [Test]
        public void GetAsync()
        {
            // Arrange
            var serializer = this.serializerBuilder
                .Build();

            // Act
            var sut = new FileDbObjectRepository<SerializeSchema, int>(serializer);

            // Assert
            Assert.Pass();
        }
    }
}