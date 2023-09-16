using System;
using System.Collections.Generic;

namespace Mov.Core.Stores
{
    public interface IRead<TEntity>
    {
        IEnumerable<TEntity> ReadAll();
        TEntity Read(Guid id);

    }
}
