using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Templates.Crud
{
    public interface ISave<TEntity>
    {
        void Save(TEntity entity);
    }
}
