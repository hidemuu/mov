using Mov.Core.Accessors.Clients;
using Mov.Core.Accessors.Models;
using Mov.Core.Repositories.Services;
using Mov.Core.Repositories.Test.Builders;
using Mov.Core.Repositories.Test.Models;

namespace Mov.Core.Repositories.Test
{
    [TestFixture]
    public class FileDbRepositoryTest
    {
        #region field

        private RepositorySerializerBuilder serializerBuilder;

        #endregion field

        #region setup

        [SetUp]
        public void Setup()
        {
            this.serializerBuilder = new RepositorySerializerBuilder();
        }

        #endregion setup

        #region test

        /// <summary>
        /// モックのスキーマを取得できること
        /// </summary>
        [Test]
        public void GetAsync_ReadMockSerializeSchema_ReturnAll()
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
                .WithDeserializeCalled<IEnumerable<SerializeSchema>, IEnumerable<SerializeSchema>>(schemas)
                .Build();
            var sut = FileDbRepository<SerializeSchema, int>.Factory.Create(new FileClient(PathValue.Empty, serializer));

            // Act
            var items = Task.WhenAll(sut.GetsAsync()).Result[0].ToArray();

            // Assert
            Assert.That(items.Length, Is.EqualTo(2));
            Assert.That(items[0].Id, Is.EqualTo(1));
            Assert.That(items[0].Content, Is.EqualTo("test"));
            Assert.That(items[1].Id, Is.EqualTo(2));
            Assert.That(items[1].Content, Is.EqualTo("test2"));
        }

        /// <summary>
        /// jsonファイルをデシリアライズして取得できること
        /// </summary>
        [Test]
        public void GetAsync_ReadSerializeSchema_ReturnAll()
        {
            // Arrange
            var resourcePath = PathValue.Factory.CreateResourcePath(@"test.json");
            var sut = FileDbRepository<SerializeSchema, int>.Factory.Create(resourcePath, FileType.Json, EncodingValue.UTF8);

            // Act
            var items = Task.WhenAll(sut.GetsAsync()).Result[0].ToArray();

            // Assert
            Assert.That(items.Length, Is.EqualTo(2));
            Assert.That(items[0].Id, Is.EqualTo(1));
            Assert.That(items[0].Content, Is.EqualTo("test"));
            Assert.That(items[1].Id, Is.EqualTo(2));
            Assert.That(items[1].Content, Is.EqualTo("test2"));
        }

        /// <summary>
        /// 特定IDのモックのスキーマを取得できること
        /// </summary>
        [Test]
        public void GetAsync_ReadMockSerializeSchema_Return()
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
                .WithDeserializeCalled<IEnumerable<SerializeSchema>, IEnumerable<SerializeSchema>>(schemas)
                .Build();

            // Act
            var sut = FileDbRepository<SerializeSchema, int>.Factory.Create(new FileClient(PathValue.Empty, serializer));
            var item = Task.WhenAll(sut.GetAsync(2)).Result[0];

            // Assert
            Assert.That(item.Id.Equals(2));
            Assert.That(item.Content.Equals("test2"));
        }

        #endregion test
    }
}