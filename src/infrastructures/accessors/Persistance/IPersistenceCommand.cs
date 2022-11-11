using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public interface IPersistenceCommand<T>
    {
        void Write();
        void Post(T item);

        void Delete(T item);
    }
}
