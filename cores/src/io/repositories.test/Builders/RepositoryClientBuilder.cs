using Moq;
using Mov.Core.Accessors.Services.Clients;
using Mov.Core.Accessors.Services.Serializer.FIles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public RepositoryClientBuilder WithReadCalled<TEntity>(IEnumerable<TEntity> response)
        {
            this.mockClient
                .Setup(x => x.GetAsync<TEntity>(It.IsAny<string>()))
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
