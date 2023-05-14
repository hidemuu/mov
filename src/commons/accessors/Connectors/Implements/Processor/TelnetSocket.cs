using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;

namespace Mov.Accessors.Connectors.Implements.Processor
{
    /// <summary>
    /// Telnetソケットクラス
    /// </summary>
    public partial class TelnetSocket : Component
    {
        #region コンストラクター

        public TelnetSocket()
        {
            //InitializeComponent();
        }

        public TelnetSocket(IContainer container)
        {
            container.Add(this);

            //InitializeComponent();
        }

        #endregion コンストラクター

        #region フィールド

        //ソケット
        private Socket clientSocket = null;

        private static string response = string.Empty;
        private int MAX_BUFFER_SIZE = 2048;

        public enum SocketAction
        { SA_READ, SA_WRITE, SA_CLOSE, SA_NONE }

        // イベント処理用のデリゲート
        public delegate void ConnectEventHandler(Socket client);

        public delegate void DisconnectEventHandler();

        public delegate void ReceiveEventHandler(byte[] ReceiveData);

        public delegate void SendEventHandler(byte[] SendData);

        //イベントハンドラ
        public event ConnectEventHandler Connect = null;

        public event DisconnectEventHandler Disconnect = null;

        public event ReceiveEventHandler Receive = null;

        public event SendEventHandler Send = null;

        #endregion フィールド

        #region プロパティ

        public int Port { get; set; }
        public string Host { get; set; }
        public int Timeout { get; set; }

        #endregion プロパティ

        #region イベントハンドラ

        private void DisposedEvent(object sender, EventArgs e)
        {
            Close(clientSocket);
        }

        #endregion イベントハンドラ

        #region メソッド

        /// <summary>
        /// オープン処理
        /// </summary>
        public bool Open()
        {
            try
            {
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Host);    //IPホストオブジェクトを取得
                IPAddress ipAddress = ipHostInfo.AddressList[0];    //IPアドレスを取得
                //IPv6でないアドレスを取得
                for (int i = 0; i < ipHostInfo.AddressList.Length; i++)
                {
                    if (ipHostInfo.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        ipAddress = ipHostInfo.AddressList[i];
                    }
                }
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, Port);

                //TCP/IPソケット生成
                clientSocket = new Socket(
                  AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.ReceiveTimeout = Timeout;

                try
                {
                    clientSocket.Connect(remoteEP);
                    if (Connect != null)
                    {
                        Connect(clientSocket);
                    }
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                    return false;
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                    return false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        /// <summary>
        /// クローズ処理
        /// </summary>
        public void Close(Socket client)
        {
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();

            if (Disconnect != null)
            {
                Close(clientSocket);
            }
        }

        /// <summary>
        /// バイトデータ読出
        /// </summary>
        public int Read(out byte[] bytes)
        {
            int bytesReceive = 0;
            bytes = new byte[MAX_BUFFER_SIZE];
            if (clientSocket.Available > 0)
            {
                // リモートからレスポンス読出
                bytes = new byte[clientSocket.ReceiveBufferSize];   // 受信バッファー分の配列を用意
                //bytes = new byte[MAX_BUFFER_SIZE];

                bytesReceive = clientSocket.Receive(bytes, SocketFlags.None);   //死ぬ
                if (Receive != null)
                {
                    Receive(bytes);
                }
            }
            return bytesReceive;
        }

        /// <summary>
        /// バイトデータ書込
        /// </summary>
        public int Write(byte[] data, int bytesWrite)
        {
            int bytesRec = clientSocket.Send(data, bytesWrite, SocketFlags.None);

            if (Send != null)
            {
                Send(data);
            }
            return bytesRec;
        }

        /// <summary>
        /// バイトデータ書込（オーバーライド）
        /// </summary>
        public int Write(byte[] data)
        {
            int bytesRec = clientSocket.Send(data, SocketFlags.None);
            if (Send != null)
            {
                Send(data);
            }
            return bytesRec;
        }

        #endregion メソッド
    }
}