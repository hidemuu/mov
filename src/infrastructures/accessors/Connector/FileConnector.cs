using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mov.Accessors.Connector
{
    /// <summary>
    /// ファイル接続ロジッククラス
    /// </summary>
    public static class FileConnector
    {
        /// <summary>
        /// バックアップ処理
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="backupDir"></param>
        /// <param name="backupNameAdd"></param>
        /// <returns></returns>
        public static bool Backup(string filePath, string backupDir, string backupNameAdd)
        {
            //バックアップパス生成
            var dir = System.IO.Path.GetDirectoryName(filePath);
            var file = System.IO.Path.GetFileNameWithoutExtension(filePath);
            var extension = System.IO.Path.GetExtension(filePath);
            var backupPath = backupDir + @"\" + file + "_" + backupNameAdd + extension;

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
                Console.WriteLine(DateTime.Now.ToString(DbConstants.DATE_FORMAT) + "/" + ex.Message + "/" + ex.Source + "/" + "バックアップ失敗");
                return false;
            }


            return true;
        }
        /// <summary>
        /// ディレクトリクリア処理
        /// </summary>
        /// <returns></returns>
        public static bool ClearDir(string deletePath)
        {
            System.IO.Directory.Delete(deletePath, true);
            for (int i = 0; i < 50; i++)
            {

                if (System.IO.Directory.Exists(deletePath))
                {
                    //削除対象が存在する場合
                    System.Threading.Thread.Sleep(100);
                }
                else
                {
                    //削除完了した場合
                    System.Threading.Thread.Sleep(1000);
                    System.IO.Directory.CreateDirectory(deletePath);
                    break;
                }
            }
            return true;
        }

        /// <summary>
        /// ディレクトリのサイズを取得
        /// </summary>
        /// <returns></returns>
        public static long GetDirectorySize(DirectoryInfo dirInfo)
        {
            long size = 0;
            //フォルダ内サイズを合計
            foreach (FileInfo fi in dirInfo.GetFiles())
            {
                size += fi.Length;
            }
            //サブフォルダサイズ合計
            foreach (DirectoryInfo di in dirInfo.GetDirectories())
            {
                size += GetDirectorySize(di);
            }
            return size;
        }

        /// <summary>
        /// 行数を取得
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <returns></returns>
        public static int GetLineNum(string filePath)
        {
            var reader = new System.IO.StreamReader(filePath);
            var result = 0;

            while (reader.Peek() >= 0)
            {
                reader.ReadLine();
                result++;
            }
            reader.Close();

            return result;
        }
        /// <summary>
        /// ファイル削除
        /// </summary>
        /// <returns></returns>
        public static bool DeleteFile(string filePath)
        {
            try
            {
                System.IO.File.Delete(filePath);
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}
