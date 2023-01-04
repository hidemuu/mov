using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Shemas.DesignPatterns.Creationals.Builders
{
    public interface IBuilder<T>
    {
        T Build();
    }
}
