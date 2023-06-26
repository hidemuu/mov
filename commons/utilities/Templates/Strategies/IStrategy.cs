using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers.Templates.Strategy
{
    /// <summary>クラスの振る舞いを切り替える</summary>
    public interface IStrategy
    {
        bool Execute();
        string GetCode();
        string GetNextCode();
    }
}
