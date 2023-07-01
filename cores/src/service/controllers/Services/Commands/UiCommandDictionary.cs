using Mov.Core.Templates.Controllers;
using System.Collections.Generic;

namespace Mov.Core.Controllers.Services.Commands
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
