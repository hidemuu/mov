using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Templates.Actions
{
    /// <summary>
    /// ファンクションのインターフェース
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface IFunction<TResult>
    {
        TResult Invoke();
    }
}
