using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Templates.Actions
{
    /// <summary>
    /// true / false判定のメソッドインターフェース
    /// </summary>
    public interface IPredicate
    {
        bool Invoke();
    }
}
