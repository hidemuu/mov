using Mov.Core.Repositories.Schemas.Requests;
using Mov.Core.Repositories.Services;
using Mov.Core.Repositories.Test.Builders;
using Mov.Core.Repositories.Test.Models;

namespace Mov.Core.Repositories.Test
{
    [TestFixture]
    public class RestDbRepositoryTest
    {
        #region field

        private RepositoryClientBuilder clientBuilder;

        #endregion field

        #region setup

        [SetUp]
        public void Setup()
        {
            this.clientBuilder = new RepositoryClientBuilder();
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
            var client = this.clientBuilder
                .WithGetAsyncCalled<SerializeSchema>(schemas)
                .Build();

            // Act
            var sut = new RestDbRepository<SerializeSchema, int, DbRequestSchemaString>(client, "");
            var items = Task.WhenAll(sut.GetsAsync()).Result[0].ToArray();

            // Assert
            Assert.That(items.Length, Is.EqualTo(2));
            Assert.That(items[0].Id, Is.EqualTo(1));
            Assert.That(items[0].Content, Is.EqualTo("test"));
            Assert.That(items[1].Id, Is.EqualTo(2));
            Assert.That(items[1].Content, Is.EqualTo("test2"));
        }

        #endregion test
    }
}