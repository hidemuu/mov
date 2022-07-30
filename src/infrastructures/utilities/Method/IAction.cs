using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Method
{
    public interface IAction<T>
    {
        void Do(T context);
    }
}
