using System.Collections.Generic;

namespace Mov.Core.Stores
{
    public interface IRead<TEntity, TKey>
    {
        IEnumerable<TEntity> ReadAll();
        TEntity Read(TKey id);

    }
}
