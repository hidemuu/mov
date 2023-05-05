using Mov.Accessors.Contexts;
using Mov.Schemas.Units;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mov.Accessors.Connectors.Implements.Files
{
    /// <summary>
    /// ファイル接続
    /// </summary>
    public class FileConnector : IFileConnector
    {
        #region フィールド

        private readonly FileContext _context;

        #endregion フィールド

        #region コンストラクター

        public FileConnector(FileContext context)
        {
            _context = context;
            if (!_context.Endpoint.IsDir()) throw new ArgumentException();
        }

        #endregion コンストラクター

        #region メソッド

        /// <summary>
        /// バックアップ処理
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="backupDir"></param>
        /// <param name="backupNameAdd"></param>
        /// <returns></returns>
        public bool Backup(string fileName, string backupDir, string backupNameAdd)
        {
            var file = new FileUnit(fileName);
            //バックアップパス生成
            var backupPath = backupDir +
                @"\" + file.FileName +
                "_" + backupNameAdd + file.FileExtension;

            var backupFileDir = new FileUnit(backupDir);

            //バックアップフォルダ生成（存在しない場合のみ）
            backupFileDir.CreateDirectory();

            //ファイルコピー
            try
            {
                //第3項にTrueを指定すると、コピー先が存在している時、上書き
                //上書きするファイルが読み取り専用などで上書きできない場合は、UnauthorizedAccessExceptionが発生
                File.Copy(Path.Combine(_context.Endpoint.DirName, file.Path), backupPath, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + "/" + ex.Message + "/" + ex.Source + "/" + "バックアップ失敗");
                return false;
            }


            return true;
        }
        /// <summary>
        /// ディレクトリクリア処理
        /// </summary>
        /// <returns></returns>
        public bool Clear(string deletePath)
        {
            Directory.Delete(deletePath, true);
            for (int i = 0; i < 50; i++)
            {

                if (Directory.Exists(deletePath))
                {
                    //削除対象が存在する場合
                    System.Threading.Thread.Sleep(100);
                }
                else
                {
                    //削除完了した場合
                    System.Threading.Thread.Sleep(1000);
                    Directory.CreateDirectory(deletePath);
                    break;
                }
            }
            return true;
        }

        /// <summary>
        /// ディレクトリのサイズを取得
        /// </summary>
        /// <returns></returns>
        public long GetSize()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(_context.Endpoint.DirName);
            return GetDirectorySize(dirInfo);
        }

        /// <summary>
        /// 行数を取得
        /// </summary>
        public int GetLineNum(string fileName)
        {
            var reader = new StreamReader(Path.Combine(_context.Endpoint.DirName, fileName));
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
        public bool Delete(string filePath)
        {
            try
            {
                File.Delete(filePath);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void Upload(string fileName)
        {
            throw new NotImplementedException();
        }

        #endregion メソッド

        #region 内部メソッド

        private long GetDirectorySize(DirectoryInfo dirInfo)
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

        #endregion 内部メソッド

    }
}
