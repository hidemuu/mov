using Mov.Core.Repositories;
using Mov.Core.Stores.Services.Queries.Readers;

namespace Mov.Core.Stores.Services.Queries
{
    public class DbRepositoryQuery<TEntity, TKey> : IStoreQuery<TEntity, TKey> where TEntity : IDbSchema<TKey>
    {
        public virtual IRead<TEntity, TKey> Reader { get; }

        public DbRepositoryQuery(IDbRepository<TEntity, TKey> repository)
        {
            this.Reader = new DbRepositoryReader<TEntity, TKey>(repository);
        }
    }
}
