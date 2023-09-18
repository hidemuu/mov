using Mov.Core.Accessors.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mov.Core.Accessors.Clients
{
    public class SqlClient : IClient
    {
        public PathValue Endpoint => throw new NotImplementedException();

        public Task<ResponseStatus> DeleteAsync<TEntity>(string url, TEntity item)
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

        public Task<ResponseStatus> PostAsync<TEntity>(string url, TEntity item)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseStatus> PutAsync<TEntity>(string url, TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
