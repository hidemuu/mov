using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Mov.Controllers
{
    public interface ICommandExecuter<T>
    {
        T Invoke(string command);
    }
}
