using Mov.Core.Accessors.Models;
using Mov.Core.Accessors.Services;
using Mov.Core.Accessors.Services.Clients.Implements;
using Mov.Core.Accessors.Services.Serializer;
using Mov.Core.Accessors.Services.Serializer.Implements;
using Mov.Core.Accessors.Test;
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
            var sut = new SerializerFactory(PathValue.Factory.CreateResourceRootPath(), EncodingValue.UTF8).Create(AccessType.Json);
            var obj = sut.Get<SerializeObject>("test.json");
            Assert.That(obj != null);
        }
    }
}