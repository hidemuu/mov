using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers
{
    public interface IPersistenceCommand<T>
    {
        void Post(T item);

        void Delete(T item);
    }
}
