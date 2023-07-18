using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Core.Models.Networks
{
    public sealed class ConnectValue : ValueObjectBase<ConnectValue>
    {
        #region property

        /// <inheritdoc />
        public IpAddressValue Host { get; }

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

        public ConnectValue(string ip, int port, string userName, string password, double timeout)
        {
            this.Host = new IpAddressValue(ip);
            this.Port = port;
            this.UserName = userName;
            this.Password = password;
            this.Timeout = timeout;
        }

        #endregion constructor

        #region method

        protected override bool EqualCore(ConnectValue other)
        {
            return this.Host.Equals(other.Host);
        }

        protected override int GetHashCodeCore()
        {
            return this.Host.GetHashCode();
        }

        #endregion method
    }
}
