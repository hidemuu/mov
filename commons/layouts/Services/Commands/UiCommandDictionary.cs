using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Layouts.Services.Commands
{
    /// <summary>
    /// 登録コマンドのディクショナリ
    /// </summary>
    /// <typeparam name="TParameter"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <remarks>
    /// Key : コマンド名
    /// Value : コマンドのインスタンス
    /// </remarks>
    public class UiCommandDictionary<TParameter, TResponse> : Dictionary<string, IUiCommand<TParameter, TResponse>>
    {
    }
}
