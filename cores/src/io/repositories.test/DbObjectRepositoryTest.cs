using Mov.Core.Repositories.Implements.DbObjects;
using Mov.Core.Repositories.Test.Builders;
using Mov.Core.Repositories.Test.Models;
using NUnit.Framework.Constraints;

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
            IEnumerable<SerializeSchema> schemas = new[]
                {
                    new SerializeSchema()
                    {
                        Id = 1,
                        Content = "test",
                    },
                    new SerializeSchema()
                    {
                        Id = 2,
                        Content = "test2",
                    },
                };
            var serializer = this.serializerBuilder
                .WithGetCalled(schemas)
                .Build();

            // Act
            var sut = new FileDbObjectRepository<SerializeSchema, int>(serializer);
            var items = Task.WhenAll(sut.GetAsync()).Result[0].ToArray();

            // Assert
            Assert.That(items.Length == 2);
            Assert.That(items[0].Id.Equals(1));
            Assert.That(items[1].Id.Equals(2));
        }
    }
}