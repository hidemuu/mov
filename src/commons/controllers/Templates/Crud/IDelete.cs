using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers
{
    public interface IDelete<TEntity>
    {
        void Delete(TEntity entity);
    }
}
