using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Repositories.Services
{
    public interface IEntityRepository<TEntity>
    {
        IEnumerable<TEntity> Get();

        TEntity Get(string param);

        void Post(TEntity item);
    }
}
