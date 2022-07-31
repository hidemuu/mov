using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities
{
    /// <summary>
    /// ファンクションのインターフェース
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public interface IFunction<TRequest, TResult>
    {
        TResult Invoke(TRequest parameter);
    }
}
