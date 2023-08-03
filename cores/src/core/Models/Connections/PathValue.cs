using Mov.Core.Helpers;
using Mov.Core.Models.Texts;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Mov.Core.Models.Connections
{
    public sealed class PathValue : ValueObjectBase<PathValue>
    {
        #region constant

        private const string RESOURCE_NAME = "resources";

        #endregion constant

        #region property

        /// <summary>
        /// パス文字列
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// ファイル名
        /// </summary>
        public string FileName => Path.GetFileNameWithoutExtension(this.Value);

        /// <summary>
        /// 拡張子
        /// </summary>
        public string Extension => Path.GetExtension(this.Value);

        /// <summary>
        /// ドライブパス
        /// </summary>
        public string DrivePath => Directory.GetDirectoryRoot(this.Value);

        /// <summary>
        /// ディレクトリパス
        /// </summary>
        public string DirPath => IsDir() ? this.Value : Directory.GetParent(this.Value).FullName;

        /// <summary>
        /// ディレクトリ名
        /// </summary>
        public string DirName => Directory.GetParent(this.Value).Name;

        #endregion property

        #region constructor

        public PathValue(string path) 
        {
            this.Value = string.IsNullOrEmpty(path) ? path : Path.IsPathRooted(path) ? path : Path.Combine(PathHelper.GetAssemblyRootPath(), path);
        }

        public static PathValue Empty = new PathValue(string.Empty);

        public static class Factory
        {
            public static PathValue CreateSolutionRootPath(string solutionName)
            {
                return new PathValue(PathHelper.GetCurrentRootPath(solutionName));
            }

            public static PathValue CreateAssemblyRootPath()
            {
                return new PathValue(PathHelper.GetAssemblyRootPath());
            }

            public static PathValue CreateResourceRootPath()
            {
                return new PathValue(Path.Combine(PathHelper.GetAssemblyRootPath(), PathValue.RESOURCE_NAME));
            }

            public static PathValue CreateResourcePath(string fileName)
            {
                return new PathValue(Path.Combine(PathHelper.GetAssemblyRootPath(), PathValue.RESOURCE_NAME, fileName));
            }

            public static PathValue CreateResourceRootPath(string solutionName)
            {
                return new PathValue(Path.Combine(PathHelper.GetCurrentRootPath(solutionName), PathValue.RESOURCE_NAME));
            }

            public static PathValue CreateResourcePath(string solutionName, string fileName)
            {
                return new PathValue(Path.Combine(PathHelper.GetCurrentRootPath(solutionName), PathValue.RESOURCE_NAME, fileName));
            }
        }

        #endregion constructor

        #region method

        public bool IsEmpty() => string.IsNullOrEmpty(this.Value);

        public bool IsRooted() => Path.IsPathRooted(this.Value);

        public bool IsFile() => !string.IsNullOrEmpty(this.FileName) && !string.IsNullOrEmpty(this.Extension);

        public bool IsFileName() => this.Value.Equals(this.FileName, StringComparison.Ordinal);

        public bool IsDir() => IsRooted() && !IsFile();

        public string Combine(string path)
        {
            return Path.Combine(this.Value, path);
        }


        protected override bool EqualCore(PathValue other)
        {
            return this.Value.Equals(other.Value, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion method
    }
}
