using System.Collections.Generic;

namespace Mov.Core.Commands.Services
{
    /// <summary>
    /// 登録コマンドのディクショナリ
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    /// <remarks>
    /// Key : コマンド名
    /// Value : コマンドのインスタンス
    /// </remarks>
    public class UiCommandDictionary<TRequest, TResponse> : Dictionary<string, IUiCommand<TRequest, TResponse>>
    {
    }
}
