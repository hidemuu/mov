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
        public string FileName => System.IO.Path.GetFileNameWithoutExtension(Path.Value);

        /// <summary>
        /// 拡張子
        /// </summary>
        public FileType FileType => new FileType(System.IO.Path.GetExtension(Path.Value));

        /// <summary>
        /// ディレクトリ名
        /// </summary>
        public string DirName => FileType.IsEmpty() ? FileName : System.IO.Path.GetDirectoryName(Path.Value);


        #endregion property

        #region constructor

        public FileValue(string path)
        {
            Path = new PathValue(path);
        }

        #endregion constructor

        #region method

        public bool IsEmpty() => string.IsNullOrEmpty(Path.Value);

        public bool IsDir() => !string.IsNullOrEmpty(DirName) && FileType.IsEmpty();

        public bool IsFile() => !string.IsNullOrEmpty(FileName) && !FileType.IsNan();

        public bool IsFileName() => Path.Value.Equals(FileName, StringComparison.Ordinal);

        public bool IsCsvFile() => IsFile() && FileType.IsCsv();

        public bool IsXmlFile() => IsFile() && FileType.IsXml();

        public bool IsJsonFile() => IsFile() && FileType.IsJson();

        public bool Exists()
        {
            return IsDir() ? Directory.Exists(Path.Value) :
                IsFile() ? File.Exists(Path.Value) : false;
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
