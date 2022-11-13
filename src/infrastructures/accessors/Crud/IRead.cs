using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public interface IRead<T>
    {
        IEnumerable<T> ReadAll();
        T Read(Guid id);

    }
}
