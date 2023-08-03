using Mov.Core.Accessors.Services;
using Mov.Core.Accessors.Services.Clients.Implements;
using Mov.Core.Accessors.Services.Serializer.Implements;
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
            var sut = new FileAccessClient(PathValue.Factory.CreateResourcePath("test.json"), EncodingValue.UTF8);
            Assert.That(sut.File.Type.IsJson());
            Assert.That(sut.File.Exists());
        }
    }
}