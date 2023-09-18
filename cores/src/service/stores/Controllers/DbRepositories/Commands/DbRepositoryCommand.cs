using Mov.Core.Repositories;

namespace Mov.Core.Stores.Controllers.DbRepositories.Commands
{
    public class DbRepositoryCommand<TEntity, TKey> : IStoreCommand<TEntity> where TEntity : IDbSchema<TKey>
    {
        public virtual ISave<TEntity> Saver { get; }

        public virtual IDelete<TEntity> Deleter { get; }

        public DbRepositoryCommand(IDbRepository<TEntity, TKey> repository)
        {
            Saver = new DbRepositorySaver<TEntity, TKey>(repository);
            Deleter = new DbRepositoryDeleter<TEntity, TKey>(repository);
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
