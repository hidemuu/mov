using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Accessors.Connectors.Sockets
{
    public class SocketConnector : ISocketConnector
    {
        public void Connect(string IP, int port)
        {
            // ソケットをTCPプロトコルで生成
            // AddressFamily.InterNetwork: IPv4で接続(IPv6の場合はInterNetworkV6)
            // SocketType.Stream: TCPを使うので双方向のバイトストリームをサポートするStream
            // ProtocolType.Tcp: TCPなのでTcp
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // ローカルホストの8081ポートのサーバへ接続
            socket.Connect(IP, port);

            bool endRead = false; // 読み込み用スレッドの停止用

            // ログ読み取り用スレッド
            Task tasks = Task.Factory.StartNew(() =>
            {
                // exitが入力されたら終了
                while (!endRead)
                {
                    if (socket.Available > 0)
                    {
                        // 受信バッファー分の配列を用意
                        byte[] recBytes = new byte[socket.ReceiveBufferSize];
                        // 受信データの取得
                        socket.Receive(recBytes, SocketFlags.None);
                        // 受信データを文字列に変換
                        string recStr = Encoding.UTF8.GetString(recBytes).TrimEnd('\0');
                        // 受信文字列データを出力
                        if (!string.IsNullOrEmpty(recStr))
                        {
                            Console.Write(recStr);
                            Console.Write("> ");
                        }
                    }
                    // 速すぎるとCPUをバカ食いするので
                    System.Threading.Thread.Sleep(100);
                }
            });

            // 改行コード
            byte[] newLine = { 0x0D, 0x0A };
            while (true)
            {
                // 文字入力を受ける
                string inputStr = Console.ReadLine();
                // exitの時は読み取りスレッド停止とループから抜ける
                if (inputStr.Equals("exit"))
                {
                    endRead = true;
                    break;
                }

                // 入力文字を送信
                byte[] inputBytes = Encoding.UTF8.GetBytes(inputStr);
                socket.Send(inputBytes, inputBytes.Length, SocketFlags.None);
                // 改行コードを送信
                socket.Send(newLine, newLine.Length, SocketFlags.None);
            }

            // 受信スレッドを待機
            tasks.Wait();

            // 接続終了処理
            socket.Shutdown(SocketShutdown.Both);
            socket.Disconnect(false);
            socket.Dispose();

        }
    }
}
