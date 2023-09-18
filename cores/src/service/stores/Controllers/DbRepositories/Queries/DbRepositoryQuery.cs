using Mov.Core.Repositories;

namespace Mov.Core.Stores.Controllers.DbRepositories.Queries
{
    public class DbRepositoryQuery<TEntity, TIdentifier> : IStoreQuery<TEntity, TIdentifier> where TEntity : IDbSchema<TIdentifier>
    {
        public virtual IRead<TEntity, TIdentifier> Reader { get; }

        public DbRepositoryQuery(IDbRepository<TEntity, TIdentifier> repository)
        {
            Reader = new DbRepositoryReader<TEntity, TIdentifier>(repository);
        }
    }
}
