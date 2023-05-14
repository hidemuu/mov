using Mov.Schemas.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    /// <summary>
    /// 接続の共通コンテキスト
    /// </summary>
    public interface IConnectContext
    {
        /// <summary>
        /// IPアドレス
        /// </summary>
        IpAddressUnit Host { get; }

        /// <summary>
        /// ポート番号
        /// </summary>
        int Port { get; }

        /// <summary>
        /// ユーザー名
        /// </summary>
        string UserName { get; }

        /// <summary>
        /// パスワード
        /// </summary>
        string Password { get; }

        /// <summary>
        /// タイムアウト時間[msec]
        /// </summary>
        double Timeout { get; }
    }
}
