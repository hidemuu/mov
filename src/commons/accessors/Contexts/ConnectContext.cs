using Mov.Schemas.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Contexts
{
    /// <inheritdoc cref="IConnectContext" />
    public class ConnectContext : IConnectContext
    {
        #region プロパティ

        /// <inheritdoc />
        public IpAddressUnit Host { get; }

        /// <inheritdoc />
        public int Port { get; }

        /// <inheritdoc />
        public string UserName { get; }

        /// <inheritdoc />
        public string Password { get; }

        /// <inheritdoc />
        public double Timeout { get; }

        #endregion プロパティ

        #region コンストラクター

        /// <inheritdoc cref="IConnectContext" />
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
