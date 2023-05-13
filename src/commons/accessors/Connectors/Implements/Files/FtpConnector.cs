using FluentFTP;
using Mov.Accessors.Contexts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Authentication;
using System.Text;

namespace Mov.Accessors.Connectors.Implements.Files
{
    public class FtpConnector : IFileAccessor, IConnector
    {
        #region フィールド

        private readonly FtpContext _context;

        private readonly FtpClient _client;

        #endregion フィールド

        #region コンストラクター

        public FtpConnector(FtpContext context)
        {
            _context = context;
            _client = new FtpClient();
        }

        #endregion コンストラクター

        #region メソッド

        public void Connect()
        {
            if (_client.IsConnected) return;
            _client.Host = _context.Host.Value;
            _client.Port = _context.Port;
            // 資格情報の設定
            _client.Credentials = new NetworkCredential(_context.UserName, _context.Password);
            // 要求の完了後に接続を閉じる
            _client.SocketKeepAlive = false;
            // Explicit設定
            _client.EncryptionMode = FtpEncryptionMode.Explicit;
            // プロトコルはTls
            _client.SslProtocols = SslProtocols.Tls;
            // 接続タイムアウトを5秒に設定
            _client.ConnectTimeout = (int)_context.Timeout;
            // 証明書の内容を確認しない
            _client.ValidateCertificate += new FtpSslValidation(OnValidateCertificate);
        }

        public bool IsConnected()
        {
            return _client.IsConnected;
        }

        public void Disconnect()
        {
            // 切断
            _client.Disconnect();
            // 解放
            _client.Dispose();
        }

        public void Upload(string fileName)
        {
            
            try
            {
                // 接続
                Connect();
                // ファイルのアップロード
                _client.UploadFile(Path.Combine(_context.FileUnit.DirName, fileName), fileName);

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
