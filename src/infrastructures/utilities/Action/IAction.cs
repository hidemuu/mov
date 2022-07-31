using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities
{
    /// <summary>
    /// アクションのインターフェース（戻り値なし）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAction<T>
    {
        void Invoke(T parameter);
    }
}
