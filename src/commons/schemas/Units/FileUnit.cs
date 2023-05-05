using Mov.Utilities.Objects;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Mov.Schemas.Units
{
    public sealed class FileUnit : ValueObjectBase<FileUnit>
    {
        #region プロパティ

        public string Path { get; }

        public string DirName => System.IO.Path.GetDirectoryName(Path);

        public string FileName => System.IO.Path.GetFileNameWithoutExtension(Path);

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
