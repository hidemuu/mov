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
        T Read<T>();
        /// <summary>
        /// 書き込み
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        void Write<T>(T obj);
    }
}
