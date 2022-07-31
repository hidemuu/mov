using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Mov.Utilities
{
    public interface ICommandHandler<T>
    {
        Response Invoke(string command);
    }
}
