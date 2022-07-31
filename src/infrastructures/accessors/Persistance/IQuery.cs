using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public interface IQuery<T>
    {
        IEnumerable<T> Get();

        T Get(Guid id);

        IEnumerable<T> Get(string code);
    }
}
