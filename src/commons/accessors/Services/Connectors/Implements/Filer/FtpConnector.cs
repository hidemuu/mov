using FluentFTP;
using Mov.Accessors.Contexts;
using Mov.Accessors.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Authentication;
using System.Text;

namespace Mov.Accessors.Services.Connectors.Implements.Filer
{
    public class FtpConnector : IConnector, IFiler
    {
        #region フィールド

        private readonly ConnectParameter connectParameter;

        private readonly IAccessContext fileContext;

        private readonly FtpClient client;

        #endregion フィールド

        #region コンストラクター

        public FtpConnector(ConnectParameter connectParameter, IAccessContext fileContext)
        {
            this.connectParameter = connectParameter;
            this.fileContext = fileContext;
            client = new FtpClient();
        }

        #endregion コンストラクター

        #region メソッド

        #region IConnector

        public void Connect()
        {
            if (client.IsConnected) return;
            client.Host = connectParameter.Host.Value;
            client.Port = connectParameter.Port;
            // 資格情報の設定
            client.Credentials = new NetworkCredential(connectParameter.UserName, connectParameter.Password);
            // 要求の完了後に接続を閉じる
            client.SocketKeepAlive = false;
            // Explicit設定
            client.EncryptionMode = FtpEncryptionMode.Explicit;
            // プロトコルはTls
            client.SslProtocols = SslProtocols.Tls;
            // 接続タイムアウトを5秒に設定
            client.ConnectTimeout = (int)connectParameter.Timeout;
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
                client.UploadFile(Path.Combine(fileContext.FileParameter.FileUnit.DirName, fileName), fileName);

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
