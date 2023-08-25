using Mov.Core.Models.Texts;
using Mov.Core.Repositories.Implements.DbObjects;
using Mov.Core.Repositories.Test.Builders;
using Mov.Core.Repositories.Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.Repositories.Test
{
    [TestFixture]
    public class RestDbObjectRepositoryTest
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
            var sut = new RestDbObjectRepository<SerializeSchema, int>("", "", EncodingValue.UTF8);
            var items = Task.WhenAll(sut.GetAsync()).Result[0].ToArray();

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
