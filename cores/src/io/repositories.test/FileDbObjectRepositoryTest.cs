using Mov.Core.Accessors.Services.Clients.Implements;
using Mov.Core.Models.Connections;
using Mov.Core.Repositories.Implements.DbObjects;
using Mov.Core.Repositories.Test.Builders;
using Mov.Core.Repositories.Test.Models;
using NUnit.Framework.Constraints;

namespace Mov.Core.Repositories.Test
{
    [TestFixture]
    public class FileDbObjectRepositoryTest
    {
        #region field

        private FileRepositorySerializerBuilder serializerBuilder;

        #endregion field

        #region setup

        [SetUp]
        public void Setup()
        {
            this.serializerBuilder = new FileRepositorySerializerBuilder();
        }

        #endregion setup

        #region test

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
            var sut = new FileDbObjectRepository<SerializeSchema, int>(new FileClient(PathValue.Empty, serializer));
            var items = Task.WhenAll(sut.GetAsync()).Result[0].ToArray();

            // Assert
            Assert.That(items.Length, Is.EqualTo(2));
            Assert.That(items[0].Id, Is.EqualTo(1));
            Assert.That(items[0].Content, Is.EqualTo("test"));
            Assert.That(items[1].Id, Is.EqualTo(2));
            Assert.That(items[1].Content, Is.EqualTo("test2"));
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
            var sut = new FileDbObjectRepository<SerializeSchema, int>(new FileClient(PathValue.Empty, serializer));
            var item = Task.WhenAll(sut.GetAsync(2)).Result[0];

            // Assert
            Assert.That(item.Id.Equals(2));
            Assert.That(item.Content.Equals("test2"));
        }

        #endregion test
    }
}