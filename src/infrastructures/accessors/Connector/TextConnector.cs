﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Mov.Accessors.Connector
{
    public static class TextConnector
    {
        //----- 定数 -------------------------------------
        private const string ENC_NAME = "Shift_JIS";
        private const string DELIMITER = ",";
        private const string ESCAPE = "/";

        //----- ロジック ----------------------------------
        /// <summary>
        /// 一括でテキストファイルから読出し、配列に格納
        /// </summary>
        public static string[] ReadAllToArray(string filePath, string encName = ENC_NAME)
        {
            System.Text.Encoding enc = System.Text.Encoding.GetEncoding(encName);
            string[] lines = File.ReadAllLines(filePath, enc);
            return lines;
        }

        /// <summary>
        /// 一行ずつテキストファイルから読出し、配列に格納
        /// </summary>
        public static string[] ReadToArray(string filePath, string encName = ENC_NAME)
        {
            string[] lines = new string[] { };
            System.Text.Encoding enc = System.Text.Encoding.GetEncoding(encName);
            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath, enc))
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
        public static bool Write(string line, string filePath,
                                 string encName = ENC_NAME, string delimiter = DELIMITER, string escape = ESCAPE,
                                 bool isAdd = true)
        {
            try
            {
                System.Text.Encoding enc = System.Text.Encoding.GetEncoding(encName);
                var writer = new System.IO.StreamWriter(filePath, isAdd, enc);    //指定ファイルの読込ストリームを実行
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
        /// <param name="mode">書込モード true：追加 false：上書き</param>
        public static bool WriteArray(string[] items, string filePath,
                                      string encName = ENC_NAME, string delimiter = DELIMITER, string escape = ESCAPE,
                                      bool isAdd = true)
        {
            string line = "";
            foreach (string item in items)
            {
                string query = item.Replace(Environment.NewLine, escape).Replace("\r", escape).Replace("\n", escape).Replace(delimiter, escape);   //改行と区切り文字を変換
                line += query + delimiter;
            }
            line += Environment.NewLine;    //改行を付加

            return Write(line, filePath, encName, delimiter, escape, isAdd);
        }

        /// <summary>
        /// DataTableの内容をCSVファイルに保存する
        /// </summary>
        /// <param name="dt">出力するDataTable</param>
        /// <param name="filePath">保存先ファイルのパス</param>
        /// <param name="isAddHeader">ヘッダを書き込む時はtrue。</param>
        /// <param name="delimeter">区切り文字（CSVの場合「,」</param>
        public static bool WriteDataTable(DataTable dt, string filePath,
                                          string encName = ENC_NAME, string delimeter = DELIMITER,
                                          bool isAdd = true, bool isAddHeader = true)
        {
            //CSVファイルに書き込むときに使うEncoding
            System.Text.Encoding enc =
                System.Text.Encoding.GetEncoding(encName);

            try
            {
                //書き込むファイルを開く
                System.IO.StreamWriter writer =
                    new System.IO.StreamWriter(filePath, isAdd, enc);

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
        public static bool MakeDefault(string filePath, string encName = ENC_NAME)
        {
            //ヘッダー行読み出し
            var header = "";
            var enc = System.Text.Encoding.GetEncoding(encName);
            try
            {
                using (var reader = new System.IO.StreamReader(filePath, enc))
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
                System.IO.File.Delete(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + "/" + ex.Message + "/" + ex.Source + "/" + "バックアップ失敗");
                return false;
            }

            //新規生成し、ヘッダー行を付加
            try
            {
                using (var writer = new System.IO.StreamWriter(filePath, false, enc))
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
        public static string BackUp(string filePath, string backupDir, string encName = ENC_NAME)
        {
            var result = "";
            //バックアップパス生成
            var dir = System.IO.Path.GetDirectoryName(filePath);
            var file = System.IO.Path.GetFileNameWithoutExtension(filePath);
            var extension = System.IO.Path.GetExtension(filePath);
            var backupPath = backupDir + @"\" + file + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;

            //バックアップフォルダ生成（存在しない場合のみ）
            if (!System.IO.Directory.Exists(backupDir))
            {
                System.IO.Directory.CreateDirectory(backupDir);
            }

            //ファイルコピー
            try
            {
                //第3項にTrueを指定すると、コピー先が存在している時、上書き
                //上書きするファイルが読み取り専用などで上書きできない場合は、UnauthorizedAccessExceptionが発生
                System.IO.File.Copy(filePath, backupPath, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + "/" + ex.Message + "/" + ex.Source + "/" + "バックアップ失敗");
                return "";
            }
            //初期化
            if (MakeDefault(filePath)) { result = backupPath; }

            return result;
        }

        //----- 内部ロジック ----------------------------------------------------------------------------

        /// <summary>
        /// 必要ならば、文字列をダブルクォートで囲む
        /// </summary>
        private static string EncloseDoubleQuotesIfNeed(string field)
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
        private static string EncloseDoubleQuotes(string field)
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
        private static bool NeedEncloseDoubleQuotes(string field)
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
    }
}