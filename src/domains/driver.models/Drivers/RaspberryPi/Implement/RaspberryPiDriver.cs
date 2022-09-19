using Mov.Connectors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Models.RaspberryPi
{
    public class RaspberryPiDriver : IRaspberryPiDriver
    {
        #region フィールド

        private readonly SshConnector connector;

        #endregion フィールド


        #region コンストラクター

        public RaspberryPiDriver()
        {
            this.connector = new SshConnector();
        }

        #endregion コンストラクター

        #region メソッド

        public bool Connect(string host, int port, string username, string password)
        {
            return this.connector.Connect(host, port, username, password);
        }

        #endregion メソッド

    }
}
