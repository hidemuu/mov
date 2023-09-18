using Mov.Core.Repositories;

namespace Mov.Core.Stores.Controllers.DbRepositories.Commands
{
    public class DbRepositorySaver<TEntity, TKey> : ISave<TEntity> where TEntity : IDbSchema<TKey>
    {
        private readonly IDbRepository<TEntity, TKey> _repository;

        public DbRepositorySaver(IDbRepository<TEntity, TKey> repository)
        {
            _repository = repository;
        }

        public void Save(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
