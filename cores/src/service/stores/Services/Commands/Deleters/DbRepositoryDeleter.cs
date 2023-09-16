using Mov.Core.Repositories;

namespace Mov.Core.Stores.Services.Commands.Deleters
{
    public class DbRepositoryDeleter<TEntity, TKey> : IDelete<TEntity, TKey> where TEntity : IDbSchema<TKey>
    {
        private readonly IDbRepository<TEntity, TKey> _repository;

        public DbRepositoryDeleter(IDbRepository<TEntity, TKey> repository)
        {
            _repository = repository;
        }

        public void Delete(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
