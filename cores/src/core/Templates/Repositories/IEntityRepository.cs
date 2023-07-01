using System.Collections.Generic;

namespace Mov.Core.Templates.Repositories
{
    public interface IEntityRepository<TEntity>
    {
        IEnumerable<TEntity> Get();

        TEntity Get(string param);

        void Post(TEntity item);
    }
}
