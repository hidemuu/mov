using Mov.Core.Repositories;

namespace Mov.Core.Stores.Controllers.DbRepositories.Commands
{
    public class DbRepositoryDeleter<TEntity, TIdentifier> : IDelete<TEntity> where TEntity : IDbSchema<TIdentifier>
    {
        private readonly IDbRepository<TEntity, TIdentifier> _repository;

        public DbRepositoryDeleter(IDbRepository<TEntity, TIdentifier> repository)
        {
            _repository = repository;
        }

        public void Delete(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
