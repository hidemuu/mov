using Mov.Core.Accessors.Services;
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
            var sut = new FileAccessService("Resources", EncodingValue.UTF8);
            var serizlizer = sut.CreateSerializer();
            Assert.Pass();
        }
    }
}