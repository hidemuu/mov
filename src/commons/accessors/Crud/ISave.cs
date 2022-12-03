using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public interface ISave<TEntity>
    {
        void Save(TEntity entity);
    }
}
