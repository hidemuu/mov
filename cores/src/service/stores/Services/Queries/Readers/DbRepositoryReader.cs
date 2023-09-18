using Mov.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mov.Core.Stores.Services.Queries.Readers
{
    public class DbRepositoryReader<TEntity, TIdentifier> : IRead<TEntity, TIdentifier> where TEntity : IDbSchema<TIdentifier>
    {
        private readonly IDbRepository<TEntity, TIdentifier> _repository;

        public DbRepositoryReader(IDbRepository<TEntity, TIdentifier> repository)
        {
            _repository = repository;
        }

        public IEnumerable<TEntity> ReadAll()
        {
            var task = _repository.GetAsync();
            Task.WhenAll(task);
            return task.Result;
        }

        public TEntity Read(TIdentifier id)
        {
            var task = _repository.GetAsync(id);
            Task.WhenAll(task);
            return task.Result;
        }

    }
}
