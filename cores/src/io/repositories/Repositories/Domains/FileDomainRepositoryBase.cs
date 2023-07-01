using Mov.Core.Templates.Repositories;
using System.IO;

namespace Mov.Core.Repositories.Repositories.Domains
{
    public abstract class FileDomainRepositoryBase : IDomainRepository
    {
        #region フィールド

        protected readonly string endpoint;

        protected readonly string fileDir;

        /// <summary>
        /// 拡張子
        /// </summary>
        protected readonly string extension;

        protected readonly string encoding;

        #endregion フィールド

        #region プロパティ

        public abstract string DomainPath { get; }

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="extension"></param>
        public FileDomainRepositoryBase(string endpoint, string fileDir, string extension, string encoding)
        {
            this.endpoint = endpoint;
            this.fileDir = fileDir;
            this.extension = extension;
            this.encoding = encoding;
        }

        #endregion コンストラクター

        #region メソッド

        /// <summary>
        /// 相対パスを取得
        /// </summary>
        /// <returns></returns>
        public string GetRelativePath() => Path.Combine(endpoint, DomainPath);

        /// <summary>
        /// フルパスを取得
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns></returns>
        protected string GetPath(string fileName) => Path.Combine(GetRelativePath(), fileDir, fileName) + "." + extension;

        #endregion メソッド
    }
}
