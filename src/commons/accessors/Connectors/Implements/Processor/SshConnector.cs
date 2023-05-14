using Renci.SshNet;
using Renci.SshNet.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Mov.Accessors.Connectors.Implements.Processor
{
    public class SshConnector : IProcessor
    {
        #region フィールド

        private ConnectionInfo connectionInfo;
        private SshClient client;

        #endregion フィールド

        #region コンストラクター

        public SshConnector()
        {
        }

        #endregion コンストラクター

        #region メソッド

        /// <summary>
        /// パスワード認証の接続処理
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Connect(string host, int port, string username, string password)
        {
            return Connect(new PasswordConnectionInfo(host, port, username, password));
        }

        /// <summary>
        /// 鍵認証の接続処理
        /// </summary>
        /// <param name="keypath"></param>
        /// <param name="passphrase"></param>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool Connect(string host, string port, string username, string keypath, string passphrase)
        {
            var privateKeyFile = new PrivateKeyFile(keypath, passphrase);
            var auth = new PrivateKeyAuthenticationMethod(username, privateKeyFile);
            var connectionInfo = new ConnectionInfo(host, port, auth);
            return Connect(connectionInfo);
        }

        /// <summary>
        /// ポートフォワード処理
        /// </summary>
        /// <param name="localhost"></param>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public ForwardedPortLocal AddForwardedPortLocal(int localhost, string host, int port)
        {
            var forward = new ForwardedPortLocal((uint)localhost, host, (uint)port);
            client.AddForwardedPort(forward);
            forward.Start();
            return forward;
        }

        /// <summary>
        /// 接続確認
        /// </summary>
        /// <returns></returns>
        public bool IsConnected()
        {
            return client.IsConnected;
        }

        /// <summary>
        /// コマンド実行
        /// </summary>
        /// <param name="command"></param>
        public void RunCommand(string command)
        {
            client.RunCommand(command);
        }

        /// <summary>
        /// 切断処理
        /// </summary>
        public void Disconnect()
        {
            client.Disconnect();
        }

        #endregion メソッド

        #region 内部メソッド

        /// <summary>
        /// 接続処理
        /// </summary>
        /// <param name="connectionInfo"></param>
        /// <returns></returns>
        private bool Connect(ConnectionInfo connectionInfo)
        {
            this.connectionInfo = connectionInfo;
            client = new SshClient(connectionInfo);
            try
            {
                client.Connect();
                return true;
            }
            catch (SshAuthenticationException ex)
            {
                Debug.Assert(false, ex.Message);
                return false;
            }
        }

        #endregion 内部メソッド

        #region 静的メソッド

        public static void Run(string host, string username, string password, string command)
        {
            using (var client = new SshClient(host, username, password))
            {
                client.Connect();
                client.RunCommand(command);
                client.Disconnect();
            }
        }

        public string Run(string fileName, string args)
        {
            throw new NotImplementedException();
        }

        #endregion 静的メソッド
    }
}
