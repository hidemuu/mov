using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas
{
    public interface IBuilder<T>
    {
        T Build();
    }
}
