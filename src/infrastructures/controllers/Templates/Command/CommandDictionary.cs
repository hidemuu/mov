﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers
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
    public class CommandDictionary<TParameter, TResponse> : Dictionary<string, ICommand<TParameter, TResponse>>
    {
    }
}