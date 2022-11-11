using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public interface IPersistenceQuery<T>
    {
        IEnumerable<T> Gets();

        IEnumerable<T> Gets(string param);

        T Get(string param);

        T Get(Guid id);

        
    }
}
