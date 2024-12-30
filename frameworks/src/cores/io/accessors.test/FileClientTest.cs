using Mov.Core.Accessors.Clients;
using Mov.Core.Accessors.Models;
using Mov.Core.Accessors.Test.Models;

namespace Mov.Core.Accessors.Test
{
    [TestFixture]
    public class FileClientTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAsync_JsonFile_ReturnSchema()
        {
            // Arrange
            var sut = new FileClient(PathValue.Factory.CreateResourceRootPath(), AccessType.Json);
            // Act
            var results = Task.WhenAll(sut.GetsAsync<SerializeSchema>("test.json")).Result[0].ToArray();

            // Assert
            Assert.That(results != null);
            Assert.That(results[0].Id.Equals(1));
            Assert.That(results[0].Content.Equals("test"));
            Assert.That(results[1].Id.Equals(2));
            Assert.That(results[1].Content.Equals("test2"));
        }

		[Test]
		public void PostAsync_JsonFile_Return()
		{
			// Arrange
			var sut = new FileClient(PathValue.Factory.CreateResourceRootPath(), AccessType.Json);
            var entity = new SerializeSchema() { Id = 1, Content = "test1" };

			// Act
			Task.WhenAll(sut.DeletesAsync("test_post.json"));
			Task.WhenAll(sut.PostAsync("test_post.json", entity));
			var results = Task.WhenAll(sut.GetsAsync<SerializeSchema>("test_post.json")).Result[0].ToArray();

			// Assert
			Assert.That(results != null);
		}

		[Test]
		public void PostAsync_JsonIEnumerableFile_Return()
        {
            // Arrange
            var sut = new FileClient(PathValue.Factory.CreateResourceRootPath(), AccessType.Json);
			var entities = new List<SerializeSchema>()
			{
				new SerializeSchema(){ Id = 1, Content = "test1" },
				new SerializeSchema(){ Id = 2, Content = "test2" },
			};

			// Act
			Task.WhenAll(sut.DeletesAsync("test_post.json"));
			Task.WhenAll(sut.PostAsync("test_post.json", entities));
			var results = Task.WhenAll(sut.GetsAsync<SerializeSchema>("test_post.json")).Result[0].ToArray();

            // Assert
            Assert.That(results != null);
		}

		[Test]
        public void GetAsync_XmlFile_ReturnSchema()
        {
            // Arrange
            var sut = new FileClient(PathValue.Factory.CreateResourceRootPath(), AccessType.Xml);

            // Act
            var results = Task.WhenAll(sut.GetsAsync<SerializeSchemaCollection>("test.xml")).Result[0].ToArray();

            // Assert
            Assert.That(results != null);
            Assert.That(results[0].Schemas[0].Id.Equals(1));
            Assert.That(results[0].Schemas[0].Content.Equals("test"));
            Assert.That(results[0].Schemas[1].Id.Equals(2));
            Assert.That(results[0].Schemas[1].Content.Equals("test2"));
        }

        [Test]
        public void GetAsync_CsvFile_ReturnSchema()
        {
            // Arrange
            var sut = new FileClient(PathValue.Factory.CreateResourceRootPath(), AccessType.Csv);

            // Act
            var results = Task.WhenAll(sut.GetsAsync<SerializeSchema>("test.csv")).Result[0].ToArray();

            // Assert
            Assert.That(results != null);
            Assert.That(results[0].Id.Equals(0));
            Assert.That(results[0].Content.Equals("test"));
            Assert.That(results[1].Id.Equals(1));
            Assert.That(results[1].Content.Equals("test2"));
        }
    }
}