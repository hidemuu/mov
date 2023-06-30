using System;
using System.IO;

namespace Mov.Core.Models.ValueObjects.Units
{
    /// <summary>
    /// ファイルのValueObject
    /// </summary>
    public sealed class FileUnit : ValueObjectBase<FileUnit>
    {
        #region 定数

        private const string PATH_EXTENSION_JSON = "json";

        private const string PATH_EXTENSION_XML = "xml";

        private const string PATH_EXTENSION_CSV = "csv";

        private const string DELIMITER_CSV = ",";

        #endregion 定数

        #region プロパティ

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
        public string FileExtension => System.IO.Path.GetExtension(Path);


        #endregion プロパティ

        #region コンストラクター

        public FileUnit(string path)
        {
            Path = path;
        }

        #endregion コンストラクター

        #region メソッド

        public bool IsEmpty() => string.IsNullOrEmpty(Path);

        public bool IsDir() => !string.IsNullOrEmpty(DirName);

        public bool IsFile() => !string.IsNullOrEmpty(FileName);

        public bool IsFileName() => Path.Equals(FileName, StringComparison.Ordinal);

        public bool IsCsvFile() => IsFile() && FileExtension.Equals(PATH_EXTENSION_CSV, StringComparison.Ordinal);

        public bool IsXmlFile() => IsFile() && FileExtension.Equals(PATH_EXTENSION_XML, StringComparison.Ordinal);

        public bool IsJsonFile() => IsFile() && FileExtension.Equals(PATH_EXTENSION_JSON, StringComparison.Ordinal);

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

        #endregion メソッド

        #region 内部メソッド

        protected override bool EqualCore(FileUnit other)
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

        #endregion 内部メソッド

    }
}
