using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Persistance
{
    public interface ICommand<T>
    {
        void Save(T item);

        void Delete(T item);
    }
}
