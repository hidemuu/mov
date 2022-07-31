using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public interface ICommand<T>
    {
        void Post(T item);

        void Delete(T item);
    }
}
