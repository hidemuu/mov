using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Mov.Utilities
{
    public interface ICommandExecuter<T>
    {
        Response Invoke(string command);
    }
}
