using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Repositories.Models.EntityObjects
{
    public interface IEntityRepository<TEntity>
    {
        IEnumerable<TEntity> Get();

        TEntity Get(string param);

        void Post(TEntity item);
    }
}
