using Mov.Core.Accessors.Services;
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
            var sut = new FileAccessService(PathValue.Factory.CreateResourcePath(), EncodingValue.UTF8);
            var serizlizer = sut.CreateSerializer();
            Assert.Pass();
        }
    }
}