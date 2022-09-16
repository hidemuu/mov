using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    /// <summary>
    /// シリアライザーのインターフェース
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// 読み出し
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        TResponse Get<TResponse>(string url);
        /// <summary>
        /// 書き込み
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        TResponse Post<TRequest, TResponse>(string url, TRequest obj);
    }
}
