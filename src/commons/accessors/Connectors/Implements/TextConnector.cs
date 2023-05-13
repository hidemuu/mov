using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Mov.Accessors.Connectors.Implements
{
    /// <summary>
    /// テキストファイル送受信
    /// </summary>
    public class TextConnector
    {
        #region フィールド

        private readonly IFileContext _context;

        #endregion フィールド

        #region コンストラクター

        public TextConnector(IFileContext context)
        {
            _context= context;
        }

        #endregion コンストラクター 


        #region メソッド

        /// <summary>
        /// 一括でテキストファイルから読出し、配列に格納
        /// </summary>
        public string[] ReadAllToArray()
        {
            string[] lines = File.ReadAllLines(_context.FileUnit.Path, _context.Encoding);
            return lines;
        }

        /// <summary>
        /// 一行ずつテキストファイルから読出し、配列に格納
        /// </summary>
        public string[] ReadToArray()
        {
            string[] lines = new string[] { };
            if (File.Exists(_context.FileUnit.Path))
            {
                using (var reader = new StreamReader(_context.FileUnit.Path, _context.Encoding))
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


        /// <summary>
        /// 一行分テキストファイルに書き込み
        /// </summary>
        /// <param name="line">書き込み文字列</param>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="encName">エンコード名</param>
        /// <param name="delimiter">区切り文字（CSVの場合「,」)</param>
        /// <param name="escape">区切り文字が出力対象データに含まれている場合の変換対象文字</param>
        /// <param name="isAdd">書込モード true：追加 false：上書き</param>
        public bool Write(string line, string delimiter = AccessConstants.DELIMITER, string escape = AccessConstants.ESCAPE,
                                 bool isAdd = true)
        {
            try
            {
                var writer = new StreamWriter(_context.FileUnit.Path, isAdd, _context.Encoding);    //指定ファイルの読込ストリームを実行
                writer.Write(line);
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + "/" + ex.Message + "/" + ex.Source + "/" + "書き込み失敗");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 配列データで区切り、一行分テキストファイルに書き込み
        /// </summary>
        /// <param name="items">データ配列</param>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="encName">エンコード名</param>
        /// <param name="delimiter">区切り文字（CSVの場合「,」)</param>
        /// <param name="escape">区切り文字が出力対象データに含まれている場合の変換対象文字</param>
        /// <param name="isAdd">書込モード true：追加 false：上書き</param>
        public bool WriteArray(string[] items, string delimiter = AccessConstants.DELIMITER, string escape = AccessConstants.ESCAPE,
                                      bool isAdd = true)
        {
            string line = "";
            foreach (string item in items)
            {
                string query = item.Replace(Environment.NewLine, escape).Replace("\r", escape).Replace("\n", escape).Replace(delimiter, escape);   //改行と区切り文字を変換
                line += query + delimiter;
            }
            line += Environment.NewLine;    //改行を付加

            return Write(line, delimiter, escape, isAdd);
        }

        /// <summary>
        /// DataTableの内容をCSVファイルに保存する
        /// </summary>
        /// <param name="dt">出力するDataTable</param>
        /// <param name="filePath">保存先ファイルのパス</param>
        /// <param name="isAddHeader">ヘッダを書き込む時はtrue。</param>
        /// <param name="delimeter">区切り文字（CSVの場合「,」</param>
        /// <param name="encName"></param>
        /// <param name="isAdd"></param>
        public bool WriteDataTable(DataTable dt, string delimeter = AccessConstants.DELIMITER,
                                          bool isAdd = true, bool isAddHeader = true)
        {
            try
            {
                //書き込むファイルを開く
                StreamWriter writer =
                    new StreamWriter(_context.FileUnit.Path, isAdd, _context.Encoding);

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
                            writer.Write(delimeter);
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
                            writer.Write(delimeter);
                        }
                    }
                    //改行する
                    writer.Write("\r\n");
                }

                //閉じる
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + "/" + ex.Message + "/" + ex.Source + "/" + "書き込み失敗");
                return false;
            }

            return true;
        }
        /// <summary>
        /// データのヘッダー以外を削除し初期化する
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="encName"></param>
        /// <returns></returns>
        public bool MakeDefault()
        {
            //ヘッダー行読み出し
            var header = "";
            try
            {
                using (var reader = new StreamReader(_context.FileUnit.Path, _context.Encoding))
                {
                    header = reader.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + "/" + ex.Message + "/" + ex.Source + "/" + "バックアップ失敗");
                return false;
            }

            //元データ削除
            try
            {
                File.Delete(_context.FileUnit.Path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + "/" + ex.Message + "/" + ex.Source + "/" + "バックアップ失敗");
                return false;
            }

            //新規生成し、ヘッダー行を付加
            try
            {
                using (var writer = new StreamWriter(_context.FileUnit.Path, false, _context.Encoding))
                {
                    writer.WriteLine(header);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + "/" + ex.Message + "/" + ex.Source + "/" + "バックアップ失敗");
                return false;
            }
            return true;
        }

        /// <summary>
        /// バックアップ処理
        /// バックアップフォルダを生成し、対象ファイルをコピー
        /// </summary>
        /// <returns></returns>
        public string BackUp(string backupDir)
        {
            var result = "";
            //バックアップパス生成
            var dir = Path.GetDirectoryName(_context.FileUnit.Path);
            var file = Path.GetFileNameWithoutExtension(_context.FileUnit.Path);
            var extension = Path.GetExtension(_context.FileUnit.Path);
            var backupPath = backupDir + @"\" + file + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;

            //バックアップフォルダ生成（存在しない場合のみ）
            if (!Directory.Exists(backupDir))
            {
                Directory.CreateDirectory(backupDir);
            }

            //ファイルコピー
            try
            {
                //第3項にTrueを指定すると、コピー先が存在している時、上書き
                //上書きするファイルが読み取り専用などで上書きできない場合は、UnauthorizedAccessExceptionが発生
                File.Copy(_context.FileUnit.Path, backupPath, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + "/" + ex.Message + "/" + ex.Source + "/" + "バックアップ失敗");
                return "";
            }
            //初期化
            if (MakeDefault()) { result = backupPath; }

            return result;
        }

        #endregion メソッド

        #region 内部メソッド

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

        #endregion 内部メソッド
    }
}
