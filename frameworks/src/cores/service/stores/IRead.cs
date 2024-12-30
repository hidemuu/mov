using System.Collections.Generic;

namespace Mov.Core.Stores
{
    public interface IRead<TEntity, TIdentifier>
    {
        IEnumerable<TEntity> ReadAll();
        TEntity Read(TIdentifier id);

    }
}
