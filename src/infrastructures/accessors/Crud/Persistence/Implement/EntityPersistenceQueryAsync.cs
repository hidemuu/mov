using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors.Persistence.Implement
{
    public class EntityPersistenceQueryAsync<TEntity> : IPersistenceQueryAsync<TEntity>
    {
        public Task<TEntity> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(string param)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetsAsync(string param)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> ReadAsync()
        {
            throw new NotImplementedException();
        }
    }
}
