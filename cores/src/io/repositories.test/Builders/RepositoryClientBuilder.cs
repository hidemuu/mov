﻿using Moq;
using Mov.Core.Accessors;

namespace Mov.Core.Repositories.Test.Builders
{
    internal class RepositoryClientBuilder
    {
        #region field

        private readonly Mock<IClient> mockClient;

        #endregion field

        #region constructor

        public RepositoryClientBuilder()
        {
            this.mockClient = new Mock<IClient>();
        }

        #endregion constructor

        #region method

        public IClient Build()
        {
            return this.mockClient.Object;
        }

        public RepositoryClientBuilder WithGetAsyncCalled<TEntity>(IEnumerable<TEntity> response)
        {
            this.mockClient
                .Setup(x => x.GetsAsync<TEntity>(It.IsAny<string>()))
                .ReturnsAsync(response)
                .Callback(() =>
                {
                    Console.WriteLine("");
                });
            return this;
        }

        #endregion method
    }
}
