using Mov.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mov.Core.Stores.Services.Queries.Readers
{
    public class DbRepositoryReader<TEntity, TKey> : IRead<TEntity, TKey> where TEntity : IDbSchema<TKey>
    {
        private readonly IDbRepository<TEntity, TKey> _repository;

        public DbRepositoryReader(IDbRepository<TEntity, TKey> repository)
        {
            _repository = repository;
        }

        public IEnumerable<TEntity> ReadAll()
        {
            var task = _repository.GetAsync();
            Task.WhenAll(task);
            return task.Result;
        }

        public TEntity Read(TKey id)
        {
            var task = _repository.GetAsync(id);
            Task.WhenAll(task);
            return task.Result;
        }

    }
}
