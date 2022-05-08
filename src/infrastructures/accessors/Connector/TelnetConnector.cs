using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Mov.Accessors.Connector
{
    public static class TelnetConnector
    {
        //-----フィールド------------------------------------------------
        static TelnetSocket sock;
        static byte[] newLine = { 0x0D, 0x0A }; //改行コード

        //Telnet ネゴシエーションコード
        const byte cmdSE = 0xF0;    //サブネゴシエーションパラメータ終了
        const byte cmdNOP = 0xF1;   //オペレーションなし。受信側はこれを無視する
        const byte cmdDM = 0xF2;    //同期信号送出
        const byte cmdBRK = 0xF3;   //ブレーク
        const byte cmdIP = 0xF4;    //NVT接続プロセスの割込or中止
        const byte cmdAO = 0xF5;    //出力抑止
        const byte cmdAYT = 0xF6;   //AYT送信によるレスポンスチェック
        const byte cmdEC = 0xF7;    //受信側がデータストリームから最後の文字を消去
        const byte cmdEL = 0xF8;    //受信側がデータストリームから最後の行を消去（CRLFは除く）
        const byte cmdGA = 0xF9;    //送信可能通知
        const byte cmdSB = 0xFA;    //指定されたオプションでサブネゴシエーション開始
        //Telnet オプションコード
        const byte cmdWILL = 0xFB;  //指定されたオプションでの実行開始要求／現在の実行の確認を指示 受信側はDOかDONTで返答
        const byte cmdWONT = 0xFC;  //指定されたオプションでの実行または実行継続の拒否を指示 受信側はWONTで了承する
        const byte cmdDO = 0xFD;    //指定されたオプションでの相手方による実行要求／実行要求の確認を指示 受信側はWILLかWONTで返答
        const byte cmdDONT = 0xFE;  //指定されたオプションでの相手方による実行停止／要求確認を指示 受信側はDONTで了承する
        //Telnet エスケープシーケンス
        const byte cmdIAC = 0xFF;   //Telnetエスケープシーケンス

        //Telnet オプションコマンド
        const byte op_bynary_transmission = 0x00;   //受信した非IAC文字は8bitのバイナリデータと解釈される
        const byte op_echo = 0x01;                  //Telnetコネクション上でデータエコー
        const byte op_suppress_go_ahead = 0x03;     //Go-Ahead文字の転送を抑止
        const byte op_status = 0x05;                //リモート側視点のTelnetオプション状態をユーザ／プロセスから可視化
        const byte op_timing_mark = 0x06;           //受信データの処理済タイミングマーク送信を受信側に要求
        const byte op_terminal_type = 0x18;         //最適なターミナルタイプを両端で交渉する
        const byte op_end_of_record = 0x19;         //送信データをEOR文字で終了する。
        const byte op_window_size = 0x1F;           //
        const byte op_terminal_speed = 0x20;        //
        const byte op_remote_flow_control = 0x21;   //
        const byte op_linemode = 0x22;              //テキストを１文字ずつ送らず、テキストラインをローカル編集して完全形でリモート側へ送る
        const byte op_X_display_location = 0x23;    //
        const byte op_environment_variables = 0x24; //
        const byte op_authentication = 0x25;        //
        const byte op_encryption = 0x26;            //
        const byte op_new_environment = 0x27;       //

        //Telnet 制御文字（NVT文字）
        const byte cntNULL = 0x00;  //オペレーション無し
        const byte cntBEL = 0x07;   //音声又は視覚的な信号を生成
        const byte cntBS = 0x08;    //バックスペース
        const byte cntHT = 0x09;    //水平タブ
        const byte cntLF = 0x0A;    //改行
        const byte cntVT = 0x0B;    //垂直タブ
        const byte cntFF = 0x0C;    //フォームフィード
        const byte cntCR = 0x0D;    //キャリッジリターン

        //Telnet　ターミナルタイプ制御文字
        const byte ttpIS = 0x00;
        const byte ttpSEND = 0x01;

        //読出モードキー
        private enum EncKeys { IAC, ASCII, ENC }

        //----- メソッド --------------------------------------------------
        /// <summary>
        /// Telnet接続
        /// </summary>
        /// <param name="portNo">ポートNo（通常：23／ARCL：7171）</param>
        /// <param name="hostName">ホスト名（通常はIPアドレス）</param>
        /// <param name="login">ログインコマンド（ロボットは無し）</param>
        /// <param name="password"></param>
        public static string ConnectTelnet(int portNo, string hostName, string login, string password,
                                           string enc, string[] commands, string[] keys, out bool normal)
        {
            string guide = "";
            normal = false;
            //ソケット生成
            sock = new TelnetSocket();
            sock.Connect += new TelnetSocket.ConnectEventHandler(sock_Connect);
            try
            {
                //オープン処理
                sock.Port = portNo; //通常「23」モバイルロボ「7171」
                sock.Host = hostName;    //通常はIPアドレス
                sock.Timeout = 10000;
                normal = sock.Open();
            }
            catch
            {
                guide = "Fault:Net:connect";
                System.Console.WriteLine(guide);
                string inputStr = Console.ReadLine();
            }
            //オープン処理完了
            if (normal)
            {
                //ネゴシエーション
                string negoResult = "";
                if (portNo == 23)
                {
                    negoResult = DoNegotiationForWinServer(sock);
                }
                else if (portNo == 7171)
                {
                };
                //ログイン
                string loginResult = "";
                if (portNo == 23)
                {
                    loginResult = DoLoginForWinServer(negoResult, login, password, enc);
                }
                else if (portNo == 7171)
                {
                };

                //ログイン完了後処理
                for (int i = 0; i < commands.Length; i++)
                {
                    SendTelnetLine(commands[i], EncKeys.ENC, enc);
                    string recv = ReadLine(keys[i], enc);
                    string inputStr2 = Console.ReadLine();
                }

            }
            return guide;
        }

        //----- 内部メソッド --------------------------------------------------
        /// <summary>
        /// ネゴシエーション処理（Windowsサーバ用）
        /// </summary>
        static string DoNegotiationForWinServer(TelnetSocket sock)
        {
            //コマンド送信
            //SendTelnetOptionCode(cmdWONT, op_terminal_type);        //次のサブネゴシエーションにおける端末種別情報を宣言
            SendTelnetOptionCode(cmdWILL, op_terminal_type);        //次のサブネゴシエーションにおける端末種別情報を宣言
            SendTelnetOptionCode(cmdDO, op_suppress_go_ahead);      //GoAhead不要を指示
            SendTelnetOptionCode(cmdWILL, op_suppress_go_ahead);    //GoAhead抑制の宣言
            SendTelnetOptionCode(cmdDO, op_echo);                   //エコー要求
            //SendTelnetOptionCode(cmdDO, op_bynary_transmission);   //8bitバイナリ要求
            //SendTelnetOptionCode(cmdWILL, op_window_size);
            string recv = ReadTelnetLine(EncKeys.IAC, "IAC");  //サーバレスポンス受信

            //サーバレスポンスに対する返答コマンド送信
            SendTelnetOptionCode(cmdWONT, op_authentication);
            SendTelnetOptionCode(cmdWONT, op_echo); //ローカルエコー
            SendTelnetOptionCode(cmdWONT, op_new_environment);  //新環境変数
            SendTelnetSubNegotiationCode(op_window_size, new byte[] { 0x00, 0x50, 0x00, 0x18 });    //ウインドウサイズ
            //SendTelnetSubNegotiationCode(op_terminal_type, new byte[] { ttpIS, 0x01 });    //ターミナルタイプ
            //SendTelnetOptionCode(cmdWILL, op_bynary_transmission);
            //SendTelnetOptionCode(cmdWONT, op_bynary_transmission);
            //SendTelnetOptionCode(cmdDONT, op_bynary_transmission);
            SendTelnetOptionCode(cmdWILL, op_suppress_go_ahead);    //GoAhead抑制の宣言

            //サーバレスポンスをASCIIエンコードして返す
            string result = SendTelnetNegotiationWONT();
            return result;
        }
        /// <summary>
        /// ログイン処理（Windowsサーバ用）
        /// </summary>
        static string DoLoginForWinServer(string startInfo, string login, string password, string enc)
        {
            string recv = "";
            if (login != "")    //ログイン名指定がある場合
            {
                if (startInfo.IndexOf("login:") < 0)
                {
                    recv = ReadTelnetLine(EncKeys.ENC, "login:", enc);    //サーバレスポンス受信
                }
                SendTelnetLine(login + "\r", EncKeys.ASCII);    //ログインコマンド送信
            }
            else  //ログイン名指定が無い場合
            {
                byte[] data = new byte[1];
                data[0] = 0x0D;
                sock.Write(data);
            }

            //"Password"を待つ
            recv = ReadTelnetLine(EncKeys.ENC, "password:", enc);    //サーバレスポンス受信
            SendTelnetLine(password + "\r", EncKeys.ASCII);    //パスワードコマンド送信
            //ターミナルタイプ応答を待つ
            recv = ReadTelnetLine(EncKeys.IAC, "IAC SB", enc);        //サーバレスポンス受信
            SendTelnetSubNegotiationCode(op_terminal_type, new byte[] { ttpIS, 0x56, 0x54, 0x31, 0x30, 0x30 });    //ターミナルタイプ
            //">"を待つ
            recv = ReadLine(">", enc);        //サーバレスポンス受信

            return recv;
        }
        /// <summary>
        /// Telnetオプションコード送信処理
        /// </summary>
        static void SendTelnetOptionCode(byte cmd, byte op)
        {
            byte[] data = new byte[3];
            data[0] = cmdIAC;
            data[1] = cmd;
            data[2] = op;
            sock.Write(data);
        }
        /// <summary>
        /// Telnetサブネゴシエーションコード送信処理 
        /// </summary>
        static void SendTelnetSubNegotiationCode(byte op, byte[] paras)
        {
            int dataLength = 5 + paras.Length;
            byte[] data = new byte[dataLength];
            data[0] = cmdIAC;
            data[1] = cmdSB;
            data[2] = op;
            for (int i = 0; i <= paras.Length - 1; i++)
            {
                data[3 + i] = paras[i];
            }
            data[dataLength - 2] = cmdIAC;
            data[dataLength - 1] = cmdSE;
            sock.Write(data);
        }

        /// <summary>
        /// ネゴシエーション完了処理
        /// TelnetネゴシエーションレスポンスのDOに対し、全てWONTで返答する
        /// （あらかじめ指定した要求以外は全て拒否する）
        /// IACシーケンス完了でASCIIエンコードして文字列出力（次処理へ）
        /// </summary>
        static string SendTelnetNegotiationWONT()
        {
            //レスポンスキー文字列を取得できるまで受信
            string recv = "";
            while (true)
            {
                //データ読出
                byte[] data;
                int rbytes = sock.Read(out data);
                //エンコード処理
                if (data[0] != cmdIAC)  //Telnetエスケープシーケンス無しで終了
                {
                    recv = Encoding.ASCII.GetString(data).TrimEnd('\0');  //バイトデータをアスキーコードに変換
                    break;
                }
                else if (data[1] == cmdDO)
                {
                    data[1] = cmdWONT;
                    SendTelnetOptionCode(data[1], data[2]);
                }
                Thread.Sleep(0);
            }

            // 出力
            if (!string.IsNullOrEmpty(recv)) System.Console.WriteLine(recv);
            return recv;
        }

        /// <summary>
        /// Telnetデータ送信処理
        /// </summary>
        static void SendTelnetLine(string cmd, EncKeys key, string enc = "SHIFT_JIS")
        {
            switch (key)
            {
                case EncKeys.IAC: break;
                case EncKeys.ASCII: sock.Write(Encoding.ASCII.GetBytes(cmd)); break;
                case EncKeys.ENC: sock.Write(Encoding.GetEncoding(enc).GetBytes(cmd)); break;
            }
        }
        /// <summary>
        /// Telnetデータ受信処理（エンコード名は指定無ければSHIFT_JIS）
        /// </summary>
        static string ReadTelnetLine(EncKeys key, string responceKey = "", string enc = "SHIFT_JIS")
        {

            //レスポンスキー文字列を取得するまで受信（100ループでタイムアウト）
            string recv = "";
            string readlineIAC = "";
            string readlineASCII = "";
            string readlineENC = "";
            bool getKey = false;
            for (int i = 0; i < 100; i++)
            {
                //データ読出
                byte[] data;
                int rbytes = sock.Read(out data);
                //エンコード処理 - 文字コード自動判定
                if (data[0] == cmdIAC)
                {
                    recv = DataToTelnetString(data, rbytes);    //Telnetエスケープシーケンス文字がある場合
                    readlineIAC = readlineIAC + " " + recv;
                }
                //自動判定されなかった場合、指定した文字コードでエンコード
                else
                {
                    switch (key)
                    {
                        case EncKeys.IAC:
                            recv = DataToTelnetString(data, rbytes);
                            readlineIAC = readlineIAC + " " + recv;
                            break;
                        case EncKeys.ASCII:
                            recv = Encoding.ASCII.GetString(data).TrimEnd('\0');
                            readlineASCII = readlineASCII + " " + recv;
                            break;
                        case EncKeys.ENC:
                            recv = Encoding.GetEncoding(enc).GetString(data).TrimEnd('\0');
                            readlineENC = readlineENC + " " + recv;
                            break;
                        default: break;
                    }
                }
                //レスポンスキー取得判定
                if (recv.IndexOf(responceKey) >= 0) getKey = true;  //レスポンスキー文字列がある場合終了
                //読出終了判定
                if (responceKey == "") break;   //レスポンスキー無しの場合は、１度受信で終了
                if (getKey) if (recv.Length <= 0) break;    //レスポンスキー文字列取得後、受信文字列が空になったら終了

                Thread.Sleep(100);
            }
            //不要空白を削除
            readlineIAC = readlineIAC.TrimStart(' ');
            readlineASCII = readlineASCII.TrimStart(' ');
            readlineENC = readlineENC.TrimStart(' ');
            // 出力
            string readline = "";
            if (readlineIAC.Length > 0) readline += readlineIAC;
            if (readlineASCII.Length > 0) readline = readline + " " + readlineASCII;
            if (readlineENC.Length > 0) readline = readline + " " + readlineENC;
            System.Console.WriteLine(readline);
            return readline;
        }
        /// <summary>
        /// Telnet接続完了後の読出処理
        /// </summary>
        /// <param name="responceKey">読出完了キー文字列　複数ある場合はコンマで区切る</param>
        static string ReadLine(string responceKey, string enc)
        {
            string recv = "";
            string readline = "";
            byte[] data;
            bool getKey = false;
            for (int i = 0; i < 10; i++)
            {
                //データ読出
                int rbytes = sock.Read(out data);
                //エンコード処理 - 文字コード自動判定
                //recv = Encoding.UTF8.GetString(data).TrimEnd('\0');
                recv = Encoding.GetEncoding(enc).GetString(data).TrimEnd('\0');
                //recv = Encoding.GetEncoding(enc).GetString(data).Trim('\0');
                readline += recv;

                //レスポンスキー取得判定
                string[] responceKeys = responceKey.Split(',');
                for (int s = 0; s < responceKeys.Length; s++)
                {
                    if (recv.IndexOf(responceKeys[s]) >= 0) getKey = true;  //レスポンスキー文字列がある場合終了
                }
                //読出終了判定
                if (responceKey == "") break;   //レスポンスキー無しの場合は、１度受信で終了
                if (getKey) if (recv.Length <= 0) break;    //レスポンスキー文字列取得後、受信文字列が空になったら終了

                Thread.Sleep(100);
            }
            // 出力
            System.Console.WriteLine(readline);
            return readline;

        }

        /// <summary>
        /// バイトデータをTelnetコード情報に変換し、情報として可視化する
        /// </summary>
        static string DataToTelnetString(byte[] data, int dataBytes)
        {
            string result = "";
            for (int i = 0; i < Math.Min(data.Length, dataBytes); i++)
            {
                result += CmdToTelnetString(data[i]) + " ";
            }
            result = result.TrimEnd('\0');
            return result;
        }
        /// <summary>
        /// バイトデータをTelnetコード文字列に変換
        /// </summary>
        static string CmdToTelnetString(byte data)
        {
            string result = "";
            switch (data)
            {
                case 0xF0: result = "SE"; break;
                case 0xF1: result = "NOP"; break;
                case 0xF2: result = "DM"; break;
                case 0xF3: result = "BRK"; break;
                case 0xF4: result = "IP"; break;
                case 0xF5: result = "AO"; break;
                case 0xF6: result = "AYT"; break;
                case 0xF7: result = "EC"; break;
                case 0xF8: result = "EL"; break;
                case 0xF9: result = "GA"; break;
                case 0xFA: result = "SB"; break;
                case 0xFB: result = "WILL"; break;
                case 0xFC: result = "WONT"; break;
                case 0xFD: result = "DO"; break;
                case 0xFE: result = "DONT"; break;
                case 0xFF: result = "IAC"; break;
                case 0x00: result = "bynary_transmission"; break;
                case 0x01: result = "echo"; break;
                case 0x03: result = "suppress_go_ahead"; break;
                case 0x05: result = "status"; break;
                case 0x06: result = "timing_mark"; break;
                case 0x18: result = "terminal_type"; break;
                case 0x19: result = "end_of_record"; break;
                case 0x1F: result = "window_size"; break;
                case 0x20: result = "terminal_speed"; break;
                case 0x21: result = "remote_flow_control"; break;
                case 0x22: result = "linemode"; break;
                case 0x24: result = "environment_variables"; break;
                case 0x25: result = "authentication"; break;
                case 0x26: result = "encryption"; break;
                case 0x27: result = "new_environment"; break;
                default: result = "unknown"; break;
            }
            return result;
        }
        /// <summary>
        /// 接続通知
        /// </summary>
        static void sock_Connect(System.Net.Sockets.Socket client)
        {
            System.Console.WriteLine("Connect");
        }
    }
}
