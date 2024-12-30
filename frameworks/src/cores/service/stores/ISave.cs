using System.Collections;
using System.Collections.Generic;

namespace Mov.Core.Stores
{
    public interface ISave<TEntity>
    {
        void Save(IEnumerable<TEntity> entities);
        void Save(TEntity entity);
    }
}
