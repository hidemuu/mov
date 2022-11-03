using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers
{
    public interface IFactory<T>
    {
        T Create(string createType);
    }
}
