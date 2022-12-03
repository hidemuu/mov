using FluentFTP;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Authentication;
using System.Text;

namespace Mov.Connectors
{
    public class FtpConnector
    {
        #region フィールド

        #endregion フィールド

        #region コンストラクター

        public FtpConnector()
        {

        }

        #endregion コンストラクター

        #region メソッド

        public void Upload()
        {
            FtpClient client = new FtpClient();

            client.Host = "192.168.0.129";
            client.Port = 61234;
            // 資格情報の設定
            client.Credentials = new NetworkCredential("testuser", "testuser");
            // 要求の完了後に接続を閉じる
            client.SocketKeepAlive = false;
            // Explicit設定
            client.EncryptionMode = FtpEncryptionMode.Explicit;
            // プロトコルはTls
            client.SslProtocols = SslProtocols.Tls;
            // 接続タイムアウトを5秒に設定
            client.ConnectTimeout = 5000;
            // 証明書の内容を確認しない
            client.ValidateCertificate += new FtpSslValidation(OnValidateCertificate);

            try
            {
                // 接続
                client.Connect();
                // ファイルのアップロード
                client.UploadFile(@"C:\work\1.png", "1.png");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // 切断
                client.Disconnect();
                // 解放
                client.Dispose();
            }
        }

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
