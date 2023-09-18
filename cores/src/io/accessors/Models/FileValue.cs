using Mov.Core.Models;
using System;
using System.IO;

namespace Mov.Core.Accessors.Models
{
    /// <summary>
    /// ファイルのValueObject
    /// </summary>
    public sealed class FileValue : ValueObjectBase<FileValue>
    {
        #region constrant

        private const string ESCAPE = "/";

        private const string DELIMITER_CSV = ",";

        #endregion constant

        #region property

        /// <summary>
        /// フルパス
        /// </summary>
        public PathValue Path { get; }

        /// <summary>
        /// ファイル名
        /// </summary>
        public string FileName => Path.FileName;

        /// <summary>
        /// 拡張子
        /// </summary>
        public FileType Type => new FileType(Path.Extension);

        /// <summary>
        /// ディレクトリ名
        /// </summary>
        public string DirName => Type.IsEmpty() ? FileName : Path.DirPath;


        #endregion property

        #region constructor

        public FileValue(string path)
        {
            Path = new PathValue(path);
        }

        #endregion constructor

        #region method

        public bool IsEmpty() => Path.IsEmpty();

        public bool Exists()
        {
            return Path.IsDir() ? Directory.Exists(Path.Value) :
                Path.IsFile() ? File.Exists(Path.Value) : false;
        }

        public void Copy(string distPath)
        {
            try
            {
                File.Copy(Path.Value, distPath, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CopyOverWrite(string distPath)
        {
            try
            {
                File.Copy(Path.Value, distPath, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete()
        {
            try
            {
                File.Delete(Path.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool CreateDirectory()
        {
            if (Directory.Exists(DirName)) return false;
            Directory.CreateDirectory(DirName);
            return true;
        }

        public string GetDelimiter()
        {
            if (Type.IsCsv()) return DELIMITER_CSV;
            return string.Empty;
        }

        public string GetEscape()
        {
            return ESCAPE;
        }

        /// <summary>
        /// ディレクトリのサイズを取得
        /// </summary>
        public long GeDirectorytSize()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(DirName);
            return GetDirectorySize(dirInfo);
        }

        /// <summary>
        /// 行数を取得
        /// </summary>
        public int GetLineNum(string fileName)
        {
            var reader = new StreamReader(Path.Combine(fileName).Value);
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

        #region protected method

        protected override bool EqualCore(FileValue other)
        {
            return Path.Equals(other.Path);
        }

        protected override int GetHashCodeCore()
        {
            return Path.GetHashCode();
        }

        #endregion protected method

        #region private method

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
