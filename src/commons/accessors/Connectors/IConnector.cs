using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Connectors
{
    /// <summary>
    /// 接続処理のインターフェース
    /// </summary>
    public interface IConnector
    {
        void Connect();

        void Disconnect();

        bool IsConnected();
    }
}
