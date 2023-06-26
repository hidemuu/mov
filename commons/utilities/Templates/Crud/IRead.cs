using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers
{
    public interface IRead<TEntity>
    {
        IEnumerable<TEntity> ReadAll();
        TEntity Read(Guid id);

    }
}
