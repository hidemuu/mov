using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers
{
    public interface IBuilder<T>
    {
        T Build();
    }
}
