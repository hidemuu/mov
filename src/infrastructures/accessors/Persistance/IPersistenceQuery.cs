using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public interface IPersistenceQuery<T>
    {
        IEnumerable<T> Get();

        IEnumerable<T> Get(string param);

        T Get(Guid id);

        
    }
}
