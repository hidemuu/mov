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
        IpAddressUnit Host { get; }

        int Port { get; }

        string UserName { get; }

        string Password { get; }

        double Timeout { get; }
    }
}
