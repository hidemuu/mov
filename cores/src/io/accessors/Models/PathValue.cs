using Mov.Core.Helpers;
using Mov.Core.Models;
using System;
using System.IO;

namespace Mov.Core.Accessors.Models
{
    public sealed class PathValue : ValueObjectBase<PathValue>
    {
        #region constant

        private const string RESOURCE_NAME = "resources";

        private const string SQLITE_HEADER = @"Data Source=";

        #endregion constant

        #region property

        /// <summary>
        /// パス文字列
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// ファイル名
        /// </summary>
        public string FileName => Path.GetFileNameWithoutExtension(Value);

        /// <summary>
        /// 拡張子
        /// </summary>
        public string Extension => Path.GetExtension(Value);

        /// <summary>
        /// ドライブパス
        /// </summary>
        public string DrivePath => Directory.GetDirectoryRoot(Value);

        /// <summary>
        /// ディレクトリパス
        /// </summary>
        public string DirPath => IsDir() ? Value : Directory.GetParent(Value).FullName;

        /// <summary>
        /// ディレクトリ名
        /// </summary>
        public string DirName => Directory.GetParent(Value).Name;

        #endregion property

        #region constructor

        public PathValue(string path)
        {
            this.Value = 
                string.IsNullOrEmpty(path) ?
                    path : 
                    Path.IsPathRooted(path) ?
                        path : 
                        Path.Combine(PathHelper.GetAssemblyRootPath(), path);
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
                return new PathValue(Path.Combine(PathHelper.GetAssemblyRootPath(), RESOURCE_NAME));
            }

            public static PathValue CreateResourcePath(string fileName)
            {
                return new PathValue(Path.Combine(PathHelper.GetAssemblyRootPath(), RESOURCE_NAME, fileName));
            }

            public static PathValue CreateResourceRootPath(string solutionName)
            {
                return new PathValue(Path.Combine(PathHelper.GetCurrentRootPath(solutionName), RESOURCE_NAME));
            }

            public static PathValue CreateResourcePath(string solutionName, string fileName)
            {
                return new PathValue(Path.Combine(PathHelper.GetCurrentRootPath(solutionName), RESOURCE_NAME, fileName));
            }
        }

        #endregion constructor

        #region method

        public bool IsEmpty() => string.IsNullOrEmpty(Value);

        public bool IsRooted() => Path.IsPathRooted(Value);

        public bool IsFile() => !string.IsNullOrEmpty(FileName) && !string.IsNullOrEmpty(Extension);

        public bool IsFileName() => Value.Equals(FileName, StringComparison.Ordinal);

        public bool IsDir() => IsRooted() && !IsFile();

        public PathValue Combine(string path)
        {
            return Path.IsPathRooted(path) ? new PathValue(path) : new PathValue(Path.Combine(Value, path));
        }

        public Uri GetUri() => new Uri(Value);

        public string GetSqliteConnectionString() => Path.Combine(SQLITE_HEADER, Value);

        #endregion method

        #region inner method

        protected override bool EqualCore(PathValue other)
        {
            return Value.Equals(other.Value, StringComparison.Ordinal);
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        #endregion inner method
    }
}
