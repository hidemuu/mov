using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public interface IRead<TEntity>
    {
        IEnumerable<TEntity> ReadAll();
        TEntity Read(Guid id);

    }
}
