using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Templates
{
    public interface IFactory<TInstance>
    {
        TInstance Create(string param);
    }
}
