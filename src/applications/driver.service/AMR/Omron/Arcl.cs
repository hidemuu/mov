using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mov.Driver.Service.AMR.Omron
{
    public class Arcl : IAMRDriver
    {
        //----- 機能コード ------------------
        /// <summary>
        /// 接続モード
        /// </summary>
        public enum ConnectModes
        {
            SYNC = 0,
            BEGIN = 1,
            ASYNC = 2,
        }
        /// <summary>
        /// ネゴシエーションモード
        /// </summary>
        public enum NegotiateModes
        {
            SIMPLE = 0,
            KEYCHECK = 1,
        }
        /// <summary>
        /// 書き込みモード
        /// </summary>
        public enum WriteModes
        {
            SIMPLE = 0,
            WRITER = 1,
        }
        /// <summary>
        /// 読み出しモード
        /// </summary>
        public enum ReadModes
        {
            SIMPLE = 0,
            READER = 1,
        }

        //----- 定数 --------------------
        private const int C_INI_CONNECT_MODE = (int)ConnectModes.SYNC;
        private const int C_INI_NEGOTIATE_MODE = (int)NegotiateModes.SIMPLE;
        private const int C_INI_WRITE_MODE = (int)WriteModes.SIMPLE;
        private const int C_INI_READ_MODE = (int)ReadModes.SIMPLE;

        //----- フィールド --------------
        #region フィールド
        /// <summary>
        /// ホストIPアドレス
        /// </summary>
        private string _host;

        /// <summary>
        /// ホストport番号（7171固定）
        /// </summary>
        private int _port = 7171;

        /// <summary>
        /// パスワード
        /// </summary>
        private string _password;

        /// <summary>
        /// TCP接続
        /// </summary>
        private TcpClient _client;

        /// <summary>
        /// クライアントソケット
        /// </summary>
        private NetworkStream _clientStream;
        /// <summary>
        /// 読み出しソケット
        /// </summary>
        private StreamReader _clientReader;
        /// <summary>
        /// 書き込みソケット
        /// </summary>
        private StreamWriter _clientWriter;

        /// <summary>
        /// 最大読み出しバッファサイズ
        /// </summary>
        private readonly int _bufferSize = 1024;

        /// <summary>
        /// 非同期モード
        /// </summary>
        private bool _runAsync = true;

        /// <summary>
        /// 非同期モード時の遅延時間[ms]
        /// </summary>
        private int _asyncDelay;

        /// <summary>
        /// 同期制御使用オブジェクト
        /// </summary>
        private readonly object _lockObject = new object();

        /// <summary>
        /// 入力バッファー
        /// </summary>
        private byte[] _bufferIn;

        /// <summary>
        /// 出力バッファー
        /// </summary>
        private byte[] _bufferOt;
        #endregion

        //----- イベントハンドラ ----------------
        #region イベントハンドラ
        /// <summary>
        /// ARCL受信イベントハンドラのデリゲート
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        public delegate void ArclDataReceivedEventHandler(object sender, ArclEventArgs data);

        /// <summary>
        /// Event fired when data is received from Arcl.  Only valid when running async.
        /// </summary>
        public event ArclDataReceivedEventHandler ArclDataReceived;
        #endregion

        //----- コンストラクタ -------------------
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Arcl()
        {

        }

        //----- メソッド -----------------------------------------------------
        // 接続／ネゴシエーション
        //--------------------------------------------------------------------
        #region ARCLサーバ接続
        /// <summary>
        /// ARCLサーバへ接続
        /// </summary>
        /// <param name="mode">0：同期接続　1：非同期接続[ConnectBack]　2：非同期接続[ConnectAsync]+リトライ機能</param>
        /// <returns>true: 接続成功</returns>
        public bool Connect(string host, string password, int mode = C_INI_CONNECT_MODE)
        {
            _host = host;
            _password = password;
            _bufferIn = new byte[_bufferSize];
            _bufferOt = new byte[_bufferSize];

            try
            {
                //TCPクライアント生成、接続処理
                _client = new TcpClient { SendTimeout = 500 };
                switch (mode)
                {
                    case (int)ConnectModes.SYNC:
                        _client.Connect(_host, _port); break;
                    case (int)ConnectModes.BEGIN:
                        if (!ConnectWithTimeout(ref _client, 21000))
                        { return false; }
                        break;
                    case (int)ConnectModes.ASYNC:
                        if (!ConnectWithTimeoutRetry(ref _client, 21000, 3))
                        { return false; }
                        break;
                    default:
                        if (!ConnectWithTimeoutRetry(ref _client, 21000, 3))
                        { return false; }
                        break;
                }

                //ソケット生成
                _clientStream = _client.GetStream();
                _clientReader = new StreamReader(_clientStream);
                _clientWriter = new StreamWriter(_clientStream);
                _client.ReceiveTimeout = 250;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return _client.Connected;
        }
        /// <summary>
        /// ARCLサーバ接続確認
        /// </summary>
        /// <returns></returns>
        public bool Connected()
        {
            return _client.Connected;
        }

        /// <summary>
        /// ARCLネゴシエーション処理
        /// </summary>
        /// <param name="mode">0：タイミング監視無し　1：キー文字列監視＋ヘルプ読み飛ばし</param>
        /// <returns></returns>
        public bool Negotiate(int mode = C_INI_NEGOTIATE_MODE)
        {
            try
            {
                //ネゴシエーション処理
                //ユーザー名とパスワード送信
                switch (mode)
                {
                    case (int)NegotiateModes.SIMPLE: NegitiationSimple(); break;
                    case (int)NegotiateModes.KEYCHECK: NegitiationToHelpEnd(); break;
                    default: NegitiationToHelpEnd(); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;

        }

        /// <summary>
        /// ARCLサーバ切断
        /// </summary>
        /// <returns>true: 切断成功</returns>
        public bool Close()
        {
            try
            {
                _runAsync = false;
                _clientStream.Close();
                _clientReader.Close();
                _clientWriter.Close();
                _client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        #endregion

        //----- メソッド -----------------------------------------------------
        // ARCL読み出し処理
        //--------------------------------------------------------------------
        #region 読み出し
        /// <summary>
        /// ARCLサーバから文字を読み出し
        /// </summary>
        /// <returns>読出結果文字列</returns>
        public string Read(int mode = C_INI_READ_MODE)
        {
            switch (mode)
            {
                case (int)ReadModes.SIMPLE: return ReadSimple();
                case (int)ReadModes.READER: return Reader();
                default: return Reader();
            }
        }

        /// <summary>
        /// ARCLサーバから文字の終端まで連続読み出し 
        /// </summary>
        /// <returns>読出結果文字列</returns>
        public string ReadAll(out bool isSuccess, int mode = C_INI_READ_MODE)
        {
            isSuccess = true;

            switch (mode)
            {
                case (int)ReadModes.SIMPLE: return ReadAllSimple(out isSuccess);
                case (int)ReadModes.READER: return ReaderAll(out isSuccess, out int foundInddex);
                default: return ReaderAll(out isSuccess, out int foundIndex);
            }
        }
        /// <summary>
        /// ARCLサーバからキー文字が見つかるまで連続読み出し
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string ReadFound(out bool isSuccess, out int foundIndex, string key, StringComparison stringComparison = StringComparison.Ordinal)
        {
            isSuccess = true;
            return ReaderAll(out isSuccess, out foundIndex, key, stringComparison);
        }
        #endregion

        //----- メソッド -----------------------------------------------------
        // ARCL書き込み処理
        //--------------------------------------------------------------------
        #region 書き込み
        /// <summary>
        /// ARCLサーバに文字列を書き込み（自動で終端に '\r' を追加）
        /// </summary>
        /// <param name="msg"></param>
        /// <returns>true: 書き込み成功</returns>
        public bool Write(string msg, int mode = C_INI_WRITE_MODE)
        {

            switch (mode)
            {
                case (int)WriteModes.SIMPLE: return WriteSimple(msg);
                case (int)WriteModes.WRITER: return Writer(msg);
                default: return Writer(msg);
            }

        }

        /// <summary>
        /// レスポンス受信処理
        /// </summary>
        /// <param name="arcl">ARCL接続インスタンス</param>
        /// <param name="arclCommand">発行ARCLコマンド</param>
        /// <param name="isTimeOut">タイムアウトフラグ（タイムアウト無でFalse）</param>
        /// <returns>受信結果文字列</returns>
        public string Receive(string arclCommand, out bool isTimeOut)
        {
            //レスポンス受信
            int counter = 0;
            isTimeOut = false;
            string responceKey = ArclItem.GetCmndResponceKey(arclCommand);
            string arclResponse;
            Console.Write("受信待機中  ");
            do
            {
                //レスポンス文字列読み出し
                arclResponse = ReadAll(out bool isSuccess);
                //読み出し失敗時
                if (!isSuccess)
                {
                    break;
                }
                //レスポンス「Unknown command」時の処理
                if (arclResponse.StartsWith("Unknown command"))
                {
                    Console.WriteLine(arclResponse);
                    Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff" + " ") +
                                              "00020001" +
                                              " コマンド指定が正しくありません。");
                    break;
                }
                //レスポンス「CommandError: 」時の処理
                if (arclResponse.StartsWith("CommandError: "))
                {
                    Console.WriteLine(arclResponse);
                    Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff" + " ") +
                                              "00020001" +
                                              " コマンド指定が正しくありません。");
                    break;
                }
                //レスポンスキー文字列が空白の場合
                if (responceKey == "")
                {
                    Console.WriteLine(arclResponse);
                    break;
                }
                //タイムアウト監視
                Thread.Sleep(100);
                counter++;
                if (counter % 10 == 0) { Console.Write("*"); }
                if (counter > 100) { isTimeOut = true; break; }

            } while (string.IsNullOrEmpty(arclResponse) ||
                     arclResponse.StartsWith(responceKey) == false);

            //受信結果表示
            return arclResponse;

        }

        /// <summary>
        /// 基本実行コマンド
        /// </summary>
        /// <returns></returns>
        public string WriteReceive(string command, string param = "")
        {
            //コマンド生成
            string fullCommand = command;
            if (param != "") fullCommand = fullCommand + " " + param;

            //コマンド送信
            Write(fullCommand);
            Console.WriteLine("発行コマンド：" + fullCommand);

            //レスポンス受信
            string arclResponse = Receive(command, out bool isTimeOut);

            //受信結果表示
            Console.WriteLine(); //改行
            Console.WriteLine("レスポンス：" + arclResponse);
            if (isTimeOut) { Console.WriteLine("タイムアウトしました"); arclResponse += "/timeOut"; }
            return arclResponse;
        }

        #endregion

        //----- ファンクションブロック --------------------------------------
        // 特定コマンド発行ブロック
        // going to goals, etc.
        //-------------------------------------------------------------------
        #region FB：ゴール取得
        /// <summary>
        /// ゴールリストの取得（getgoals）
        /// </summary>
        /// <returns>Goal list</returns>
        public List<string> GetGoals()
        {

            Write("getgoals");
            Thread.Sleep(500);

            List<string> goals = new List<string>();

            string goalsString = ReadAll(out bool isSuccess);
            string[] rawGoals = goalsString.Split('\r');

            foreach (string s in rawGoals)
            {
                if (s.IndexOf("Goal: ", StringComparison.Ordinal) >= 0)
                {
                    string goal = s.Replace("Goal: ", String.Empty);
                    goal = goal.Trim('\n', '\r');
                    goals.Add(goal);
                }
            }
            goals.Sort();
            return goals;
        }
        #endregion

        #region FB：情報取得
        /// <summary>
        /// LD名称の取得
        /// </summary>
        /// <returns>true：コマンド成功</returns>
        public bool GetLDName(int ldNum, out string[] ldNames)
        {
            try
            {
                string msg = string.Empty;    //受信文字列
                int foundIndex = 0;           //文字列照合POS
                int foundIndexEachLD = 0;     //文字列照合POS (切り出しサイズ)
                int ldcount = 0;              //LDの台数カウンタ
                ldNames = new string[ldNum];

                //コマンド発行
                Write("queueShowRobot default");
                //LD名取得
                while (_client.Connected == true)
                {
                    if (_clientReader.EndOfStream == false)
                    {
                        //１行読み出し
                        msg = Read((int)ReadModes.READER);
                        //ロボット台数分　キー文字列有無チェック
                        foundIndex = msg.IndexOf("QueueRobot: \"", StringComparison.Ordinal);
                        if (foundIndex >= 0)
                        {
                            //Console.WriteLine("***** LD名称 *****");
                            foundIndexEachLD = msg.IndexOf("\"", foundIndex + "QueueRobot: \"".Length);
                            if (ldNum > ldcount)
                            {
                                ldNames[ldcount] = msg.Substring(foundIndex + "QueueRobot: \"".Length,
                                    foundIndexEachLD - "QueueRobot: \"".Length);
                            }
                            ldcount++;
                            continue;
                        }
                        //コマンドエンド文字列チェック
                        foundIndex = msg.IndexOf("EndQueueShowRobot", StringComparison.Ordinal);
                        if (foundIndex >= 0)
                        {
                            //Console.WriteLine("***** LD一覧取得のエンド *****");
                            return true;
                        }

                        //コマンドエラー文字列チェック
                        foundIndex = msg.IndexOf("CommandError: ", StringComparison.Ordinal);
                        if (foundIndex >= 0)
                        {
                            //Console.WriteLine("***** コマンドエラー *****");
                            //コンソールメッセージ出力
                            Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff" + " ") +
                                              "00020001" +
                                              " コマンド指定が正しくありません。");

                            break;
                        }


                        foundIndex = msg.IndexOf("Unknown command ", StringComparison.Ordinal);
                        if (foundIndex >= 0)
                        {
                            //Console.WriteLine("***** コマンドUnknown *****");
                            //コンソールメッセージ出力
                            Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff" + " ") +
                                              "00020001" +
                                              " コマンド指定が正しくありません。");

                            break;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                //コンソールメッセージ出力
                Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff" + " ") +
                                  "99999999" +
                                  " 予期せぬエラーが発生しました。" +
                                  ex.Message + Environment.NewLine + ex.StackTrace.ToString()
                );

                ldNames = null;
                return false;
            }
        }
        /// <summary>
        /// LDブロードキャストメッセージから状況判定
        /// </summary>
        /// <param name="targetString"></param>
        /// <returns></returns>
        public ArclStatusIndexs MoniterMoblieTracking(ref string targetString)
        {
            try
            {
                string msg = string.Empty;    //受信文字列
                int foundIndex = 0;           //文字列照合POS

                while (_client.Connected == true)
                {
                    if (_clientReader.EndOfStream == false)
                    {
                        //１行読み出し
                        msg = Read();

                        //除外：
                        foundIndex = msg.IndexOf(ArclItem.GetStatusKey(ArclStatusIndexs.INTERRUPT));
                        if (foundIndex >= 0) { continue; }
                        //EStop 解除
                        foundIndex = msg.IndexOf(ArclItem.GetStatusKey(ArclStatusIndexs.ESTOP_OFF));
                        if (foundIndex >= 0) { return ArclStatusIndexs.ESTOP_OFF; }
                        //EStop 押下
                        foundIndex = msg.IndexOf(ArclItem.GetStatusKey(ArclStatusIndexs.ESTOP_ON));
                        if (foundIndex >= 0) { return ArclStatusIndexs.ESTOP_ON; }
                        //停止中
                        foundIndex = msg.IndexOf(ArclItem.GetStatusKey(ArclStatusIndexs.IDLE_STOP));
                        if (foundIndex >= 0) { return ArclStatusIndexs.IDLE_STOP; }
                        //Park
                        foundIndex = msg.IndexOf(ArclItem.GetStatusKey(ArclStatusIndexs.IDLE_PARK));
                        if (foundIndex >= 0) { return ArclStatusIndexs.IDLE_PARK; }
                        //充電中
                        foundIndex = msg.IndexOf(ArclItem.GetStatusKey(ArclStatusIndexs.IDLE_DOCK));
                        if (foundIndex >= 0) { return ArclStatusIndexs.IDLE_DOCK; }
                        //Pick upゴールに移動
                        foundIndex = msg.IndexOf(ArclItem.GetStatusKey(ArclStatusIndexs.PICKUP_GOING));
                        if (foundIndex >= 0)
                        {
                            targetString = msg.Substring(
                                foundIndex +
                                ArclItem.GetStatusKey(ArclStatusIndexs.PICKUP_GOING).Length - 1,
                                "  ".Length);
                            return ArclStatusIndexs.PICKUP_GOING;
                        }
                        //Pick up完了
                        foundIndex = msg.IndexOf(ArclItem.GetStatusKey(ArclStatusIndexs.PICKUP_ARRIVE));
                        if (foundIndex >= 0)
                        {
                            targetString = msg.Substring(
                                foundIndex +
                                ArclItem.GetStatusKey(ArclStatusIndexs.PICKUP_ARRIVE).Length - 1,
                                "  ".Length);
                            return ArclStatusIndexs.PICKUP_ARRIVE;
                        }
                        //Pick upゴール移動中の経路問題発生
                        foundIndex = msg.IndexOf(ArclItem.GetStatusKey(ArclStatusIndexs.PICKUP_FAILED));
                        if (foundIndex >= 0) { return ArclStatusIndexs.PICKUP_FAILED; }
                        //Drop offゴールに移動
                        foundIndex = msg.IndexOf(ArclItem.GetStatusKey(ArclStatusIndexs.DROPOFF_GOING));
                        if (foundIndex >= 0)
                        {
                            targetString = msg.Substring(
                                foundIndex +
                                ArclItem.GetStatusKey(ArclStatusIndexs.DROPOFF_GOING).Length - 1,
                                "  ".Length);
                            return ArclStatusIndexs.DROPOFF_GOING;
                        }
                        //Drop off完了
                        foundIndex = msg.IndexOf(ArclItem.GetStatusKey(ArclStatusIndexs.DROPOFF_ARRIVE));
                        if (foundIndex >= 0)
                        {
                            targetString = msg.Substring(
                                foundIndex +
                                ArclItem.GetStatusKey(ArclStatusIndexs.DROPOFF_ARRIVE).Length - 1,
                                "  ".Length);
                            return ArclStatusIndexs.DROPOFF_ARRIVE;
                        }
                        //Drop offゴール移動中の経路問題発生
                        foundIndex = msg.IndexOf(ArclItem.GetStatusKey(ArclStatusIndexs.DROPOFF_FAILED));
                        if (foundIndex >= 0) { return ArclStatusIndexs.DROPOFF_FAILED; }
                        //JOBID
                        foundIndex = msg.IndexOf(ArclItem.GetStatusKey(ArclStatusIndexs.JOBID));
                        if (foundIndex >= 0)
                        {
                            targetString = msg.Substring(foundIndex, 20);
                            return ArclStatusIndexs.JOBID;
                        }
                    }
                    else
                    {
                        return ArclStatusIndexs.NONE;
                    }
                }

                return ArclStatusIndexs.NONE;
            }
            catch
            {
                return ArclStatusIndexs.NONE;
            }
        }
        #endregion

        #region FB：キューコマンド
        /// <summary>
        /// EMへのキューピックアップ指令（queuepickup） 
        /// </summary>
        /// <param name="goal"></param>
        /// <param name="oJobid"></param>
        /// <returns>true: コマンド成功</returns>
        public bool QueuePickup(string goal, out string oJobid)
        {
            //コマンド発行
            Write("queuepickup " + goal);

            //レスポンス読出
            Thread.Sleep(500);
            string result = Read();

            // レスポンスキー文字列チェック
            int idx = result.IndexOf("queuepickup", StringComparison.Ordinal);
            if (idx < 0)
            {
                oJobid = "null";
                return false;
            }

            // JOB ID文字列チェック
            string sub = result.Substring(idx);
            idx = sub.IndexOf("job_id", StringComparison.Ordinal);
            if (idx < 0)
            {
                oJobid = "null";
                return false;
            }

            // JOB ID取得
            sub = sub.Substring(idx);
            string[] splt = sub.Split(' ');
            oJobid = splt[1];
            if (oJobid.Contains("JOB"))
                return true;

            oJobid = "null";
            return false;
        }

        /// <summary>
        /// キューリクエストキャンセル指令（queuecancel）
        /// </summary>
        /// <param name="jobId">キャンセル対象JobID</param>
        /// <returns>true: コマンド成功</returns>
        public bool QueueCancel(string jobId)
        {
            bool status = Write("queuecancel jobid " + jobId);
            return status;
        }

        /// <summary>
        /// キュークエリ（queuequery）
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="oStatus"></param>
        /// <returns>true: コマンド成功</returns>
        public bool QueueQuery(string jobId, out string oStatus)
        {
            //コマンド発行
            bool status = Write("queuequery jobID " + jobId);
            //読出
            Thread.Sleep(500);
            var result = Read();
            oStatus = result;
            return status;
        }
        #endregion

        //----- 内部メソッド ----------------------------
        //接続／ネゴシエーション／書込／読出／変換
        //-----------------------------------------------
        #region 内部メソッド <接続/ネゴシエーション>
        /// <summary>
        /// 非同期による接続処理（タイムアウト監視）[BeginConnect]
        /// </summary>
        /// <param name="tcp"></param>
        /// <param name="timeout"></param>
        /// <returns>true: 接続成功</returns>
        private bool ConnectWithTimeout(ref TcpClient tcp, int timeout)
        {
            bool connected;
            IAsyncResult ar = tcp.BeginConnect(_host, _port, null, null);
            WaitHandle wh = ar.AsyncWaitHandle;
            try
            {
                if (!ar.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(timeout), false))
                {
                    tcp.Close();
                    connected = false;
                }
                else
                {
                    connected = true;
                }
                tcp.EndConnect(ar);
            }
            finally
            {
                wh.Close();
            }
            return connected;
        }

        /// <summary>
        /// 非同期による接続処理（タイムアウト監視＋リトライ処理）[ConnectAsync]
        /// </summary>
        /// <param name="tcp"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        private bool ConnectWithTimeoutRetry(ref TcpClient tcp, int timeout, int retryNum)
        {
            try
            {
                int retryCount = 0; //リトライ回数

                while (true)
                {
                    //タイマー指定コネクト
                    Task connTask = tcp.ConnectAsync(_host, _port);
                    if (connTask.Wait(timeout))    // 接続拒否などは AggregateException
                    {
                        //接続時
                        return true;
                    }

                    //接続不可時
                    tcp.Close();
                    //ここではコンソールメッセージ出力をしておりません。

                    //接続モード確認

                    if (retryNum == 0)
                    {
                        break;
                    }
                    if (retryNum != -1)
                    {
                        if (retryCount >= retryNum)
                        {
                            break;
                        }
                    }

                    retryCount++;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 簡易ネゴシエーション処理（パスワード入力）
        /// </summary>
        private bool NegitiationSimple()
        {
            Read((int)ReadModes.SIMPLE);
            Write(_password, (int)WriteModes.SIMPLE);
            Read((int)ReadModes.SIMPLE);
            ReadAll(out bool isSuccess);

            return isSuccess;
        }
        /// <summary>
        /// ネゴシエーション処理（パスワード入力＋ヘルプ読み飛ばし）
        /// </summary>
        private bool NegitiationToHelpEnd()
        {
            string msg = "";
            try
            {
                bool isSuccess = false;
                int foundIndex = 0;
                //パスワード入力キー文字列まで連続読み出し
                msg = ReadFound(out isSuccess, out foundIndex, "Enter password:");
                if (isSuccess)
                {
                    //パスワード発行
                    //Console.WriteLine("***** パスワード入力*****");
                    Write(_password, (int)WriteModes.WRITER);
                    //ヘルプ終了キー文字列まで連続読み出し
                    msg = ReadFound(out isSuccess, out foundIndex, "End of commands");
                    if (isSuccess)
                    {
                        //Console.WriteLine("***** ヘルプのエンド *****");
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 内部メソッド <書き込み/読み出し>

        /// <summary>
        /// 簡易書き込み処理
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private bool WriteSimple(string msg)
        {
            msg += '\r';
            try
            {
                lock (_lockObject)
                {
                    StringToBytes(msg, ref _bufferOt);
                    _clientStream.Write(_bufferOt, 0, _bufferOt.Length);
                    Bzero(_bufferOt);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// ライターストリームを使用した書き込み処理
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private bool Writer(string msg)
        {
            try
            {
                _clientWriter.WriteLine(msg);
                _clientWriter.Flush();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
        /// <summary>
        /// 簡易読み出し処理
        /// </summary>
        /// <returns></returns>
        private string ReadSimple()
        {
            string msg = "";
            try
            {
                lock (_lockObject)
                {
                    Bzero(_bufferIn);
                    int length = _clientStream.Read(_bufferIn, 0, _bufferSize);
                    if (length > 0)
                    {
                        msg = BytesToString(_bufferIn);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return msg;
        }
        /// <summary>
        /// リーダーストリームを使用した読み出し処理
        /// </summary>
        /// <returns></returns>
        private string Reader()
        {
            try
            {
                return _clientReader.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }

        }
        /// <summary>
        /// 簡易読み出し処理（終端まで連続実行）
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <returns></returns>
        private string ReadAllSimple(out bool isSuccess)
        {
            isSuccess = true;
            string msg = "";
            try
            {
                while (_clientStream.DataAvailable)
                {
                    string tmp = ReadSimple();
                    if (tmp == "") break;
                    msg += tmp;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isSuccess = false;
                return msg;
            }

            return msg;
        }
        /// <summary>
        /// リーダーストリームを使用した読み出し処理（終端まで連続実行）
        /// ※keyに文字を設定した場合は、その文字が見つかるまで実行
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <returns></returns>
        private string ReaderAll(out bool isSuccess, out int foundIndex, string key = "", StringComparison stringComparison = StringComparison.Ordinal)
        {
            isSuccess = true;
            string msg = "";
            foundIndex = 0;
            try
            {
                while (_client.Connected == true)
                {
                    if (_clientReader.EndOfStream == false)
                    {
                        msg += Reader();
                        //検索文字列がある場合
                        if (key != "")
                        {
                            foundIndex = msg.IndexOf(key, stringComparison);
                            if (foundIndex >= 0)
                            {
                                isSuccess = true;
                                return msg;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isSuccess = false;
                return msg;
            }
            //検索文字列がある場合で、終端まで見つからなかった場合
            if (key != "")
            {
                isSuccess = false;
            }
            return msg;
        }

        #endregion

        #region 内部メソッド <非同期制御/変換処理>

        /// <summary>
        /// バッファーゼロリセット
        /// </summary>
        /// <param name="buff"></param>
        private void Bzero(byte[] buff)
        {
            for (int i = 0; i < buff.Length; i++)
            {
                buff[i] = 0;
            }
        }

        /// <summary>
        /// 非同期接続の起動 This will attempt reads at a specified rate
        /// and fire events when data is received.
        /// </summary>
        public void RunAsync(int rate)
        {
            _asyncDelay = rate;
            _runAsync = true;
            ThreadPool.QueueUserWorkItem(worker_DoWork);
        }

        /// <summary>
        /// 非同期読み出しタスクの停止
        /// </summary>
        public void CancelAsync()
        {
            _runAsync = false;
            Thread.Sleep(100);
        }

        /// <summary>
        /// The background thread for reading data from the socket in async mode.
        /// </summary>
        /// <param name="sender"></param>
        void worker_DoWork(object sender)
        {
            try
            {
                while (_runAsync)
                {
                    var msg = ReadAll(out bool isSuccess);
                    if (msg.Length > 0)
                    {
                        Console.WriteLine(msg);

                        // Fire the event if there are subscribers
                        if (ArclDataReceived != null)
                        {
                            ArclDataReceived(this, new ArclEventArgs(msg));
                        }
                    }
                    Thread.Sleep(_asyncDelay);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 文字列をバイト型配列として変換
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public byte[] StringToBytes(string msg)
        {
            var buffer = System.Text.Encoding.ASCII.GetBytes(msg);
            return buffer;
        }

        /// <summary>
        /// 文字列をバイト型配列として変換 （既存フィールドの更新）
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="buffer"></param>
        public void StringToBytes(string msg, ref byte[] buffer)
        {
            Bzero(buffer);
            buffer = System.Text.Encoding.ASCII.GetBytes(msg);
        }

        /// <summary>
        /// バイト型配列を文字列に変換
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns>変換結果文字列</returns>
        public string BytesToString(byte[] buffer)
        {
            string msg = System.Text.Encoding.ASCII.GetString(buffer, 0, buffer.Length);
            return msg;
        }
        #endregion

    }
}
