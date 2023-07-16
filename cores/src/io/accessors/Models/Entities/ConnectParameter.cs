using Mov.Core.Models.Networks;

namespace Mov.Core.Accessors.Models.Entities
{
    public sealed class ConnectParameter
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

        public ConnectParameter(string ip, int port, string userName, string password, double timeout)
        {
            Host = new IpAddressValue(ip);
            Port = port;
            UserName = userName;
            Password = password;
            Timeout = timeout;
        }

        #endregion constructor
    }
}
