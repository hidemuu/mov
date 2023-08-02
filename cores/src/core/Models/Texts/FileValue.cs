using Mov.Core.Models.Connections;
using System;
using System.IO;

namespace Mov.Core.Models.Texts
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
        public string FileName => this.Path.FileName;

        /// <summary>
        /// 拡張子
        /// </summary>
        public FileType Type => new FileType(this.Path.Extension);

        /// <summary>
        /// ディレクトリ名
        /// </summary>
        public string DirName => this.Type.IsEmpty() ? this.FileName : this.Path.DirPath;


        #endregion property

        #region constructor

        public FileValue(PathValue path)
        {
            Path = path;
        }

        #endregion constructor

        #region method

        public bool IsEmpty() => this.Path.IsEmpty();

        public bool IsCsvFile() => this.Path.IsFile() && this.Type.IsCsv();

        public bool IsXmlFile() => this.Path.IsFile() && this.Type.IsXml();

        public bool IsJsonFile() => this.Path.IsFile() && this.Type.IsJson();

        public bool Exists()
        {
            return this.Path.IsDir() ? Directory.Exists(Path.Value) :
                this.Path.IsFile() ? File.Exists(Path.Value) : false;
        }

        public void Copy(string distPath)
        {
            try
            {
                File.Copy(this.Path.Value, distPath, false);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CopyOverWrite(string distPath)
        {
            try
            {
                File.Copy(this.Path.Value, distPath, true);
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
                File.Delete(this.Path.Value);
            }
            catch(Exception ex) 
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
            if (IsCsvFile()) return DELIMITER_CSV;
            return string.Empty;
        }

        public string GetEscape()
        {
            return ESCAPE;
        }

        /// <summary>
        /// ディレクトリのサイズを取得
        /// </summary>
        /// <returns></returns>
        public long GetSize()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(DirName);
            return GetDirectorySize(dirInfo);
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

        #endregion private method
    }
}
