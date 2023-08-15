using Mov.Core.Accessors.Models;
using Mov.Core.Accessors.Services.Serializer;
using Mov.Core.Accessors.Test.Models;
using Mov.Core.Models.Connections;
using Mov.Core.Models.Texts;

namespace Accessors.Test
{
    [TestFixture]
    public class SerializerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void JsonSerializer_DeserializeCollection_ReturnSchema()
        {
            // Arrange & Act
            var sut = new SerializerFactory(PathValue.Factory.CreateResourceRootPath(), EncodingValue.UTF8).Create(AccessType.Json);
            var obj = sut.Read<SerializeSchema, SerializeSchemaCollection>("test_collection.json");

            // Assert
            Assert.That(obj != null);
            Assert.That(obj.Schemas[0].Id.Equals(1));
            Assert.That(obj.Schemas[0].Content.Equals("test"));
            Assert.That(obj.Schemas[1].Id.Equals(2));
            Assert.That(obj.Schemas[1].Content.Equals("test2"));
        }

        [Test]
        public void JsonSerializer_Deserialize_ReturnSchema()
        {
            // Arrange & Act
            var sut = new SerializerFactory(PathValue.Factory.CreateResourceRootPath(), EncodingValue.UTF8).Create(AccessType.Json);
            var obj = sut.Read<SerializeSchema, IEnumerable<SerializeSchema>>("test.json").ToArray();

            // Assert
            Assert.That(obj != null);
            Assert.That(obj[0].Id.Equals(1));
            Assert.That(obj[0].Content.Equals("test"));
            Assert.That(obj[1].Id.Equals(2));
            Assert.That(obj[1].Content.Equals("test2"));
        }

        [Test]
        public void XmlSerializer_DeserializeCollection_ReturnSchema()
        {
            // Arrange & act
            var sut = new SerializerFactory(PathValue.Factory.CreateResourceRootPath(), EncodingValue.UTF8).Create(AccessType.Xml);
            var obj = sut.Read<SerializeSchema, SerializeSchemaCollection>("test.xml");

            // Assert
            Assert.That(obj != null);
            Assert.That(obj.Schemas[0].Id.Equals(1));
            Assert.That(obj.Schemas[0].Content.Equals("test"));
            Assert.That(obj.Schemas[1].Id.Equals(2));
            Assert.That(obj.Schemas[1].Content.Equals("test2"));
        }

        [Test]
        public void CsvSerializer_DeserializeTest_GetSchema()
        {
            // Arrange & Act
            var sut = new SerializerFactory(PathValue.Factory.CreateResourceRootPath(), EncodingValue.UTF8).Create(AccessType.Csv);
            var obj = sut.Read<SerializeSchema, IEnumerable<SerializeSchema>>("test.csv");
            var response = obj.ToList();

            // Assert
            Assert.That(response != null);
            Assert.That(response[0].Id.Equals(0));
            Assert.That(response[0].Content.Equals("test"));
            Assert.That(response[1].Id.Equals(1));
            Assert.That(response[1].Content.Equals("test2"));
        }
    }
}