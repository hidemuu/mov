using Moq;
using Mov.Core.Accessors;

namespace Mov.Core.Repositories.Test.Builders
{
    internal class RepositorySerializerBuilder
    {
        #region field

        private readonly Mock<IFileSerializer> mockSerializer;

        #endregion field

        #region constructor

        public RepositorySerializerBuilder()
        {
            this.mockSerializer = new Mock<IFileSerializer>();
        }

        #endregion constructor

        #region method

        public IFileSerializer Build()
        {
            return this.mockSerializer.Object;
        }

        public RepositorySerializerBuilder WithDeserializeCalled<TRequest, TResponse>(TResponse response)
        {
            this.mockSerializer
                .Setup(x => x.Deserialize<TRequest, TResponse>(It.IsAny<string>()))
                .Returns(response)
                .Callback(() =>
                {
                    Console.WriteLine("");
                });
            return this;
        }

        #endregion method
    }
}