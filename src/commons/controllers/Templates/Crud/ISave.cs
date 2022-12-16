using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers
{
    public interface ISave<TEntity>
    {
        void Save(TEntity entity);
    }
}
