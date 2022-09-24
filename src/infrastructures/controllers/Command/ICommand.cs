using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Controllers
{
    /// <summary>
    /// コマンドのインターフェース
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommand<TParameter, TResponse>
    {
        /// <summary>
        /// 実行
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        TResponse Invoke(TParameter parameter, string[] args);

        /// <summary>
        /// 説明
        /// </summary>
        /// <returns></returns>
        string Help();
    }
}
