using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.DesignPatterns
{
    public interface IFactory<TInstance>
    {
        TInstance Create(string param);
    }
}
