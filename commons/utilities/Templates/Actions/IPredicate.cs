using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers
{
    /// <summary>
    /// true / false判定のメソッドインターフェース
    /// </summary>
    public interface IPredicate
    {
        bool Invoke();
    }
}
