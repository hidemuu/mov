using System;
using System.IO;

namespace Mov.Core.Models.Units
{
    /// <summary>
    /// ファイルのValueObject
    /// </summary>
    public sealed class FileValue : ValueObjectBase<FileValue>
    {
        #region constrant

        private const string DELIMITER_CSV = ",";

        #endregion constant

        #region property

        /// <summary>
        /// フルパス
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// ディレクトリ名
        /// </summary>
        public string DirName => System.IO.Path.GetDirectoryName(Path);

        /// <summary>
        /// ファイル名
        /// </summary>
        public string FileName => System.IO.Path.GetFileNameWithoutExtension(Path);

        /// <summary>
        /// 拡張子
        /// </summary>
        public FileType FileType => new FileType(System.IO.Path.GetExtension(Path));


        #endregion property

        #region constructor

        public FileValue(string path)
        {
            Path = path;
        }

        #endregion constructor

        #region method

        public bool IsEmpty() => string.IsNullOrEmpty(Path);

        public bool IsDir() => !string.IsNullOrEmpty(DirName);

        public bool IsFile() => !string.IsNullOrEmpty(FileName);

        public bool IsFileName() => Path.Equals(FileName, StringComparison.Ordinal);

        public bool IsCsvFile() => IsFile() && FileType.IsCsv();

        public bool IsXmlFile() => IsFile() && FileType.IsXml();

        public bool IsJsonFile() => IsFile() && FileType.IsJson();

        public bool Exists()
        {
            return IsDir() ? Directory.Exists(Path) :
                IsFile() ? File.Exists(Path) : false;
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
            return Path.Equals(other.Path, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return Path.GetHashCode();
        }

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

        #endregion protected method

    }
}
