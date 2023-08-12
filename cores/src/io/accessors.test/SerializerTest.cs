using Mov.Core.Accessors.Models;
using Mov.Core.Accessors.Services;
using Mov.Core.Accessors.Services.Clients.Implements;
using Mov.Core.Accessors.Services.Serializer;
using Mov.Core.Accessors.Services.Serializer.Implements;
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
        public void JsonSerializer_DeserializeTest_GetContent()
        {
            // Arrange & Act
            var sut = new SerializerFactory(PathValue.Factory.CreateResourceRootPath(), EncodingValue.UTF8).Create(AccessType.Json);
            var obj = sut.Read<SerializeSchemaCollection>("test.json");
            
            // Assert
            Assert.That(obj != null);
            Assert.That(obj.Schemas[0].Id.Equals(1));
            Assert.That(obj.Schemas[0].Content.Equals("test"));
            Assert.That(obj.Schemas[1].Id.Equals(2));
            Assert.That(obj.Schemas[1].Content.Equals("test2"));
        }

        [Test]
        public void XmlSerializer_DeserializeTest_GetContent()
        {
            // Arrange & act
            var sut = new SerializerFactory(PathValue.Factory.CreateResourceRootPath(), EncodingValue.UTF8).Create(AccessType.Xml);
            var obj = sut.Read<SerializeSchemaCollection>("test.xml");
            
            // Assert
            Assert.That(obj != null);
            Assert.That(obj.Schemas[0].Id.Equals(1));
            Assert.That(obj.Schemas[0].Content.Equals("test"));
            Assert.That(obj.Schemas[1].Id.Equals(2));
            Assert.That(obj.Schemas[1].Content.Equals("test2"));
        }

        [Test]
        public void CsvSerializer_DeserializeTest_GetContent()
        {
            // Arrange & Act
            var sut = new SerializerFactory(PathValue.Factory.CreateResourceRootPath(), EncodingValue.UTF8).Create(AccessType.Csv);
            var obj = sut.Read<SerializeSchemaCollection>("test.csv");
            
            // Assert
            Assert.That(obj != null);
            Assert.That(obj.Schemas[0].Id.Equals(1));
            Assert.That(obj.Schemas[0].Content.Equals("test"));
            Assert.That(obj.Schemas[1].Id.Equals(2));
            Assert.That(obj.Schemas[1].Content.Equals("test2"));
        }
    }
}