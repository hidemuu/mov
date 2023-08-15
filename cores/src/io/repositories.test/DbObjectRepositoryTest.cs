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
        public void GetAsync_ReadSerializeSchema_ReturnAll()
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
                .WithReadCalled<SerializeSchema, IEnumerable<SerializeSchema>>(schemas)
                .Build();

            // Act
            var sut = new FileDbObjectRepository<SerializeSchema, int>(serializer);
            var items = Task.WhenAll(sut.GetAsync()).Result[0].ToArray();

            // Assert
            Assert.That(items.Length == 2);
            Assert.That(items[0].Id.Equals(1));
            Assert.That(items[1].Id.Equals(2));
        }

        [Test]
        public void GetAsync_ReadSerializeSchema_Return()
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
                .WithReadCalled<SerializeSchema, IEnumerable<SerializeSchema>>(schemas)
                .Build();

            // Act
            var sut = new FileDbObjectRepository<SerializeSchema, int>(serializer);
            var item = Task.WhenAll(sut.GetAsync(2)).Result[0];

            // Assert
            Assert.That(item.Id.Equals(2));
            Assert.That(item.Content.Equals("test2"));
        }
    }
}