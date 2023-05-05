using Mov.Schemas.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Contexts
{
    public class FtpContext : IConnectContext, IFileContext
    {
        #region プロパティ

        public IpAddressUnit Host { get; }

        public int Port { get; }

        public string UserName { get; }

        public string Password { get; }

        public double Timeout { get; }

        public FileUnit Endpoint { get; }

        public Encoding Encoding { get; }

        #endregion プロパティ

        #region コンストラクター

        public FtpContext(string ip, int port, string userName, string password, double timeout, string endpoint)
        {
            this.Host = new IpAddressUnit(ip);
            this.Port = port;
            this.UserName = userName;
            this.Password = password;
            this.Timeout = timeout;
            this.Endpoint = new FileUnit(endpoint);
            this.Encoding = Encoding.UTF8;
        }

        #endregion コンストラクター

    }
}
