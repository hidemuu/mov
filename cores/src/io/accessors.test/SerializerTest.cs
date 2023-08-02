using Mov.Core.Accessors.Services;
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
            var sut = new FileAccessService(PathValue.Factory.CreateResourcePath("test.json"), EncodingValue.UTF8);
            var serizlizer = sut.CreateSerializer();
            Assert.That(sut.File.IsJsonFile());
            Assert.That(serizlizer is JsonSerializer);
        }
    }
}