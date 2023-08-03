using Mov.Core.Accessors.Services.Serializer.Implements;
using Mov.Core.Accessors.Services.Serializer;
using Mov.Core.Loggers;
using Mov.Core.Models.Texts;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using Mov.Core.Models.Connections;

namespace Mov.Core.Accessors.Services.Clients.Implements
{
    /// <inheritdoc/>
    public class FileAccessClient : IAccessClient
    {
        #region property

        /// <inheritdoc/>
        public FileValue File { get; }

        /// <inheritdoc/>
        public EncodingValue Encoding { get; }

        #endregion property

        #region constructor

        public FileAccessClient(PathValue path, EncodingValue encoding)
        {
            Encoding = encoding;
            File = new FileValue(path);
        }

        #endregion constructor

        #region method

        public string Read(string url)
        {
            using (var stream = CreateStreamReader(url))
            {
                if (stream != null)
                {
                    return stream.ReadToEnd();
                }
            }
            return "";
        }

        /// <inheritdoc/>
        public string[] ReadLines()
        {
            string[] lines = new string[] { };
            if (File.Exists())
            {
                using (var reader = new StreamReader(File.Path.Value, Encoding.Value))
                {
                    int i = 0;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        lines[i] = line;
                        i++;
                    }
                }
            }
            return lines;
        }


        public StreamReader CreateStreamReader(string url)
        {
            return new StreamReader(File.Path.Combine(url), Encoding.Value);
        }

        public void Write(string url, string writeString, bool isappend)
        {
            using (var stream = CreateStreamWriter(url, isappend))
            {
                if (stream != null)
                {
                    stream.Write(writeString);
                }
            }
        }

        public StreamWriter CreateStreamWriter(string url, bool isAppend)
        {
            return new StreamWriter(File.Path.Combine(url), isAppend, Encoding.Value);
        }

        /// <summary>
        /// DataTableの内容をCSVファイルに保存する
        /// </summary>
        /// <param name="dt">出力するDataTable</param>
        /// <param name="isAddHeader">ヘッダを書き込む時はtrue。</param>
        /// <param name="isAdd"></param>
        public bool Write(DataTable dt, bool isAdd = true, bool isAddHeader = true)
        {
            try
            {
                //書き込むファイルを開く
                using (StreamWriter writer = new StreamWriter(File.Path.Value, isAdd, Encoding.Value))
                {
                    string delimiter = File.GetDelimiter();
                    int colCount = dt.Columns.Count;
                    int lastColIndex = colCount - 1;

                    //ヘッダを書き込む
                    if (isAddHeader)
                    {
                        for (int i = 0; i < colCount; i++)
                        {
                            //ヘッダの取得
                            string field = dt.Columns[i].Caption;
                            //"で囲む
                            field = EncloseDoubleQuotesIfNeed(field);
                            //フィールドを書き込む
                            writer.Write(field);
                            //区切り文字を書き込む
                            if (lastColIndex > i)
                            {
                                writer.Write(delimiter);
                            }
                        }
                        //改行する
                        writer.Write("\r\n");
                    }

                    //レコードを書き込む
                    foreach (DataRow row in dt.Rows)
                    {
                        for (int i = 0; i < colCount; i++)
                        {
                            //フィールドの取得
                            string field = row[i].ToString();
                            //"で囲む
                            field = EncloseDoubleQuotesIfNeed(field);
                            //フィールドを書き込む
                            writer.Write(field);
                            //区切り文字を書き込む
                            if (lastColIndex > i)
                            {
                                writer.Write(delimiter);
                            }
                        }
                        //改行する
                        writer.Write("\r\n");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now.ToString(LogConstants.TIME_FORMAT) + "/" + ex.Message + "/" + ex.Source + "/" + "書き込み失敗");
                return false;
            }

            return true;
        }

        /// <inheritdoc/>
        public bool WriteLine(string line, bool isAdd = true)
        {
            try
            {
                using (var writer = new StreamWriter(File.Path.Value, isAdd, Encoding.Value))
                {
                    //指定ファイルの読込ストリームを実行
                    writer.Write(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now.ToString(LogConstants.TIME_FORMAT) + "/" + ex.Message + "/" + ex.Source + "/" + "書き込み失敗");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 配列データで区切り、一行分テキストファイルに書き込み
        /// </summary>
        /// <param name="items">データ配列</param>
        /// <param name="isAdd">書込モード true：追加 false：上書き</param>
        public bool WriteLine(string[] items, bool isAdd = true)
        {
            string line = "";
            string delimiter = File.GetDelimiter();
            string escape = File.GetEscape();
            foreach (string item in items)
            {
                string query = item.Replace(Environment.NewLine, escape).Replace("\r", escape).Replace("\n", escape);   //改行と区切り文字を変換
                if (string.IsNullOrEmpty(delimiter)) query.Replace(delimiter, escape);
                line += query + delimiter;
            }
            line += Environment.NewLine;    //改行を付加

            return WriteLine(line, isAdd);
        }



        /// <inheritdoc/>
        public string BackUp(string backupDirectory)
        {
            var result = "";
            //バックアップパス生成
            var backupPath = backupDirectory + @"\" + File.FileName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + File.Type;

            //バックアップフォルダ生成（存在しない場合のみ）
            if (!Directory.Exists(backupDirectory))
            {
                Directory.CreateDirectory(backupDirectory);
            }

            //ファイルコピー
            try
            {
                //第3項にTrueを指定すると、コピー先が存在している時、上書き
                //上書きするファイルが読み取り専用などで上書きできない場合は、UnauthorizedAccessExceptionが発生
                File.Copy(backupPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now.ToString(LogConstants.TIME_FORMAT) + "/" + ex.Message + "/" + ex.Source + "/" + "バックアップ失敗");
                return "";
            }
            //初期化
            if (CreateDefault()) { result = backupPath; }

            return result;
        }

        /// <summary>
        /// クリア処理
        /// </summary>
        /// <returns></returns>
        public bool Clear()
        {
            var path = File.Path.Value;
            if (File.Path.IsDir())
            {
                Directory.Delete(path, true);
                for (int i = 0; i < 50; i++)
                {
                    if (Directory.Exists(path))
                    {
                        //削除対象が存在する場合
                        System.Threading.Thread.Sleep(100);
                    }
                    else
                    {
                        //削除完了した場合
                        System.Threading.Thread.Sleep(1000);
                        Directory.CreateDirectory(path);
                        break;
                    }
                }
                return true;
            }
            else
            {
                try
                {
                    File.Delete();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// 行数を取得
        /// </summary>
        public int GetLineNum(string fileName)
        {
            var reader = new StreamReader(File.Path.Combine(fileName));
            var result = 0;

            while (reader.Peek() >= 0)
            {
                reader.ReadLine();
                result++;
            }
            reader.Close();

            return result;
        }

        #endregion method

        #region private method

        /// <summary>
        /// データのヘッダー以外を削除し初期化する
        /// </summary>
        /// <returns></returns>
        private bool CreateDefault()
        {
            //ヘッダー行読み出し
            var header = "";
            try
            {
                using (var reader = new StreamReader(File.Path.Value, Encoding.Value))
                {
                    header = reader.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now.ToString(LogConstants.TIME_FORMAT) + "/" + ex.Message + "/" + ex.Source + "/" + "バックアップ失敗");
                return false;
            }

            //元データ削除
            try
            {
                File.Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now.ToString(LogConstants.TIME_FORMAT) + "/" + ex.Message + "/" + ex.Source + "/" + "バックアップ失敗");
                return false;
            }

            //新規生成し、ヘッダー行を付加
            try
            {
                using (var writer = new StreamWriter(File.Path.Value, false, Encoding.Value))
                {
                    writer.WriteLine(header);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now.ToString(LogConstants.TIME_FORMAT) + "/" + ex.Message + "/" + ex.Source + "/" + "バックアップ失敗");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 必要ならば、文字列をダブルクォートで囲む
        /// </summary>
        private string EncloseDoubleQuotesIfNeed(string field)
        {
            if (NeedEncloseDoubleQuotes(field))
            {
                return EncloseDoubleQuotes(field);
            }
            return field;
        }

        /// <summary>
        /// 文字列をダブルクォートで囲む
        /// </summary>
        private string EncloseDoubleQuotes(string field)
        {
            if (field.IndexOf('"') > -1)
            {
                //"を""とする
                field = field.Replace("\"", "\"\"");
            }
            return "\"" + field + "\"";
        }

        /// <summary>
        /// 文字列をダブルクォートで囲む必要があるか調べる
        /// </summary>
        private bool NeedEncloseDoubleQuotes(string field)
        {
            return field.IndexOf('"') > -1 ||
                field.IndexOf(',') > -1 ||
                field.IndexOf('\r') > -1 ||
                field.IndexOf('\n') > -1 ||
                field.StartsWith(" ") ||
                field.StartsWith("\t") ||
                field.EndsWith(" ") ||
                field.EndsWith("\t");
        }

        #endregion private method
    }
}