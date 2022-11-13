using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors.Persistence.Implement
{
    public class EntityPersistenceCommandAsync<TEntity> : IPersistenceCommandAsync<TEntity>
    {
        public Task DeleteAsync(TEntity item)
        {
            throw new NotImplementedException();
        }

        public Task PostAsync(TEntity item)
        {
            throw new NotImplementedException();
        }

        public Task PostsAsync(IEnumerable<TEntity> items)
        {
            throw new NotImplementedException();
        }

        public Task PutAsync(TEntity item)
        {
            throw new NotImplementedException();
        }

        public Task WriteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
