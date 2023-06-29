namespace Mov.Core.Accessors.Services.Connectors
{
    /// <summary>
    /// 接続処理のインターフェース
    /// </summary>
    public interface IConnector
    {
        void Connect();

        void Disconnect();

        bool IsConnected();
    }
}
