using Mov.Driver.Clients.Resas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Engine.Resas
{
    public interface IResasService
    {
        IResasEngine Engine { get; }
    }
}
