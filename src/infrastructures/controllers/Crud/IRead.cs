using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers
{
    public interface IRead<T>
    {
        T Read(Guid id);

        IEnumerable<T> ReadAll();
    }
}
