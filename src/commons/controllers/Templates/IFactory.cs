using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers
{
    public interface IFactory<TInstance>
    {
        TInstance Create(string param);
    }
}
