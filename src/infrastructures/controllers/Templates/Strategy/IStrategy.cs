using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers.Templates.Strategy
{
    public interface IStrategy
    {
        bool Execute();
        string GetCode();
        string GetNextCode();
    }
}
