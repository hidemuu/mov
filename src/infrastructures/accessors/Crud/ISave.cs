using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public interface ISave<T>
    {
        void Save(T entity);
    }
}
