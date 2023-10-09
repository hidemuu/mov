using Mov.Core.Accessors.Connectors;
using Mov.Driver.Service;

namespace Mov.Suite.DriverClient.RaspberryPi
{
    public class RaspberryPiDriver : IRaspberryPiClient
    {
        #region フィールド

        private readonly SshConnector connector;

        #endregion フィールド

        #region コンストラクター

        public RaspberryPiDriver()
        {
            connector = new SshConnector();
        }

        #endregion コンストラクター

        #region メソッド

        public bool Connect(string host, int port, string username, string password)
        {
            return connector.Connect(host, port, username, password);
        }

        #endregion メソッド
    }
}