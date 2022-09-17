using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers
{
    /// <summary>
    /// コマンドのインターフェース
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommand<T>
    {
        Response Invoke(T parameter);
    }
}
