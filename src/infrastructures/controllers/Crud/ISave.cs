using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers
{
    public interface ISave<T>
    {
        void Save(T entity);
    }
}
