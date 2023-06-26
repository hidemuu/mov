using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Templates.Crud
{
    public interface IDelete<TEntity>
    {
        void Delete(TEntity entity);
    }
}
