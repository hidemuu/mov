using Mov.Schemas.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Contexts
{
    public class ConnectContext : IConnectContext
    {
        #region プロパティ

        public IpAddressUnit Host { get; }

        public int Port { get; }

        public string UserName { get; }

        public string Password { get; }

        public double Timeout { get; }

        #endregion プロパティ

        #region コンストラクター

        public ConnectContext(string ip, int port, string userName, string password, double timeout)
        {
            this.Host = new IpAddressUnit(ip);
            this.Port = port;
            this.UserName = userName;
            this.Password = password;
            this.Timeout = timeout;
        }

        #endregion コンストラクター
    }
}
