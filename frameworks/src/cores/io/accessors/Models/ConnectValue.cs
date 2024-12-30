using Mov.Core.Models;

namespace Mov.Core.Accessors.Models
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
            Host = new IpAddressValue(ip);
            Port = port;
            UserName = userName;
            Password = password;
            Timeout = timeout;
        }

        #endregion constructor

        #region method

        protected override bool EqualCore(ConnectValue other)
        {
            return Host.Equals(other.Host);
        }

        protected override int GetHashCodeCore()
        {
            return Host.GetHashCode();
        }

        #endregion method
    }
}
