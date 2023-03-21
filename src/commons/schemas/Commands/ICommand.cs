using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Schemas.Commands
{
    public interface ICommand
    {
        void Execute();
    }
}
