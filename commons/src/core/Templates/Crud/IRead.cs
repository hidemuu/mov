using System;
using System.Collections.Generic;

namespace Mov.Core.Templates.Crud
{
    public interface IRead<TEntity>
    {
        IEnumerable<TEntity> ReadAll();
        TEntity Read(Guid id);

    }
}
