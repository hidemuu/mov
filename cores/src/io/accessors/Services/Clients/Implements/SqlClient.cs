using Mov.Core.Models.Connections;
using Mov.Core.Models.Texts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.Accessors.Services.Clients.Implements
{
    public class SqlClient : IClient
    {
        public PathValue Path => throw new NotImplementedException();

        public EncodingValue Encoding => throw new NotImplementedException();

        public Task DeleteAsync<TEntity>(string url, TEntity item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAsync<TEntity>(string url)
        {
            throw new NotImplementedException();
        }

        public Task PostAsync<TEntity>(string url, TEntity item)
        {
            throw new NotImplementedException();
        }
    }
}
