using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Utilities.Templates.Actions
{
    /// <summary>
    /// アクションのインターフェース（戻り値なし）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAction<TParameter>
    {
        void Invoke(TParameter parameter);
    }
}
