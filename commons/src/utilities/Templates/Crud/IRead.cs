using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Templates.Crud
{
    public interface IRead<TEntity>
    {
        IEnumerable<TEntity> ReadAll();
        TEntity Read(Guid id);

    }
}
