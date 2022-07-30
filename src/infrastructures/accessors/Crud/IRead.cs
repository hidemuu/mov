using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public interface IRead<T>
    {
        T Read(Guid id);

        IEnumerable<T> ReadAll();
    }
}
