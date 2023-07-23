using FluentFTP;
using Mov.Core.Models.Connections;
using System;
using System.IO;
using System.Net;
using System.Security.Authentication;

namespace Mov.Core.Accessors.Services.Connectors.Implements.Filer
{
    public class FtpConnector : IConnector, IFiler
    {
        #region フィールド

        private readonly ConnectValue connect;

        private readonly IFileService fileContext;

        private readonly FtpClient client;

        #endregion フィールド

        #region コンストラクター

        public FtpConnector(ConnectValue connect, IFileService fileContext)
        {
            this.connect = connect;
            this.fileContext = fileContext;
            client = new FtpClient();
        }

        #endregion コンストラクター

        #region メソッド

        #region IConnector

        public void Connect()
        {
            if (client.IsConnected) return;
            client.Host = connect.Host.Value;
            client.Port = connect.Port;
            // 資格情報の設定
            client.Credentials = new NetworkCredential(connect.UserName, connect.Password);
            // 要求の完了後に接続を閉じる
            client.SocketKeepAlive = false;
            // Explicit設定
            client.EncryptionMode = FtpEncryptionMode.Explicit;
            // プロトコルはTls
            client.SslProtocols = SslProtocols.Tls;
            // 接続タイムアウトを5秒に設定
            client.ConnectTimeout = (int)connect.Timeout;
            // 証明書の内容を確認しない
            client.ValidateCertificate += new FtpSslValidation(OnValidateCertificate);
        }

        public bool IsConnected()
        {
            return client.IsConnected;
        }

        public void Disconnect()
        {
            // 切断
            client.Disconnect();
            // 解放
            client.Dispose();
        }

        #endregion IConnector

        #region IFiler

        public void Upload(string fileName)
        {

            try
            {
                // 接続
                Connect();
                // ファイルのアップロード
                client.UploadFile(System.IO.Path.Combine(fileContext.FileValue.DirName, fileName), fileName);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }

        #endregion IFiler

        #endregion メソッド

        #region 内部メソッド

        private void OnValidateCertificate(FtpClient control, FtpSslValidationEventArgs e)
        {
            // 証明書の内容を確認しない
            e.Accept = true;
        }

        #endregion 内部メソッド
    }
}
