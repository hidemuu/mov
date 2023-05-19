using FluentFTP;
using Mov.Accessors.Contexts;
using Mov.Accessors.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Authentication;
using System.Text;

namespace Mov.Accessors.Connectors.Implements.Filer
{
    public class FtpConnector : IConnector, IFiler
    {
        #region フィールド

        private readonly ConnectParameter connectParameter;

        private readonly IFileAccessContext fileContext;

        private readonly FtpClient client;

        #endregion フィールド

        #region コンストラクター

        public FtpConnector(ConnectParameter connectParameter, IFileAccessContext fileContext)
        {
            this.connectParameter = connectParameter;
            this.fileContext = fileContext;
            this.client = new FtpClient();
        }

        #endregion コンストラクター

        #region メソッド

        #region IConnector

        public void Connect()
        {
            if (this.client.IsConnected) return;
            this.client.Host = connectParameter.Host.Value;
            this.client.Port = connectParameter.Port;
            // 資格情報の設定
            this.client.Credentials = new NetworkCredential(connectParameter.UserName, connectParameter.Password);
            // 要求の完了後に接続を閉じる
            this.client.SocketKeepAlive = false;
            // Explicit設定
            this.client.EncryptionMode = FtpEncryptionMode.Explicit;
            // プロトコルはTls
            this.client.SslProtocols = SslProtocols.Tls;
            // 接続タイムアウトを5秒に設定
            this.client.ConnectTimeout = (int)connectParameter.Timeout;
            // 証明書の内容を確認しない
            this.client.ValidateCertificate += new FtpSslValidation(OnValidateCertificate);
        }

        public bool IsConnected()
        {
            return this.client.IsConnected;
        }

        public void Disconnect()
        {
            // 切断
            this.client.Disconnect();
            // 解放
            this.client.Dispose();
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
                this.client.UploadFile(Path.Combine(this.fileContext.FileParameter.FileUnit.DirName, fileName), fileName);

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
