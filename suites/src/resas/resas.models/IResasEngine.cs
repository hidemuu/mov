using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Clients.Resas
{
    public interface IResasEngine
    {
        IResasCommand Command { get; }

        IResasQuery Query { get; }
    }
}
