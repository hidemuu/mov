using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public interface IDelete<T>
    {
        void Delete(T entity);
    }
}
