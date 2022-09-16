using Mov.Accessors.Connector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Models.RaspberryPi
{
    public class RaspiDriver : IRaspiDriver
    {
        #region フィールド

        private readonly SshConnector connector;

        #endregion フィールド


        #region コンストラクター

        public RaspiDriver()
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
