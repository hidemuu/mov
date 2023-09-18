using Mov.Core.Repositories;
using Mov.Core.Stores.Services.Queries.Readers;

namespace Mov.Core.Stores.Services.Queries
{
    public class DbRepositoryQuery<TEntity, TIdentifier> : IStoreQuery<TEntity, TIdentifier> where TEntity : IDbSchema<TIdentifier>
    {
        public virtual IRead<TEntity, TIdentifier> Reader { get; }

        public DbRepositoryQuery(IDbRepository<TEntity, TIdentifier> repository)
        {
            this.Reader = new DbRepositoryReader<TEntity, TIdentifier>(repository);
        }
    }
}
