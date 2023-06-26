using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Templates.Builders
{
    public interface IBuilder<T>
    {
        T Build();
    }
}
