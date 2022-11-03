using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers
{
    public interface IDelete<T>
    {
        void Delete(T entity);
    }
}
