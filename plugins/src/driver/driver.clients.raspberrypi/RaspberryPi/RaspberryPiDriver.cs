using Mov.Accessors.Services.Connectors.Implements.Processor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Driver.Os.RaspberryPi
{
    public class RaspberryPiDriver : IRaspberryPiClient
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
