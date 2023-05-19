using Mov.Schemas.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Entities
{
    public sealed class ConnectParameter
    {
        #region property

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

        #endregion property

        #region constructor

        public ConnectParameter(string ip, int port, string userName, string password, double timeout)
        {
            this.Host = new IpAddressUnit(ip);
            this.Port = port;
            this.UserName = userName;
            this.Password = password;
            this.Timeout = timeout;
        }

        #endregion constructor
    }
}
