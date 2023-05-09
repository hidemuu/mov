using Mov.Utilities.Objects;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Mov.Schemas.Units
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
            this.Path = path;
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
            return IsDir() ? System.IO.Directory.Exists(Path) :
                IsFile() ? System.IO.File.Exists(Path) : false;
        }

        public bool CreateDirectory()
        {
            if (System.IO.Directory.Exists(DirName)) return false;
            System.IO.Directory.CreateDirectory(DirName);
            return true;
        }

        #endregion メソッド

        #region 内部メソッド

        protected override bool EqualCore(FileUnit other)
        {
            return this.Path.Equals(other.Path, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return this.Path.GetHashCode();
        }

        #endregion 内部メソッド

    }
}
