using Mov.Core.Templates.Repositories;
using System.IO;

namespace Mov.Core.Repositories.Repositories.Domains
{
    public abstract class FileDomainRepositoryBase : IDomainRepository
    {
        #region field

        protected string Endpoint { get; }

        /// <summary>
        /// 拡張子
        /// </summary>
        protected string Extension { get; }

        protected string Encoding { get; }

        #endregion field

        #region property

        public abstract string DomainPath { get; }

        #endregion property

        #region constructor

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="extension"></param>
        public FileDomainRepositoryBase(string endpoint, string extension, string encoding)
        {
            this.Endpoint = endpoint;
            this.Extension = extension;
            this.Encoding = encoding;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// 相対パスを取得
        /// </summary>
        /// <returns></returns>
        public string GetRelativePath() => Path.Combine(Endpoint, DomainPath);

        /// <summary>
        /// フルパスを取得
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns></returns>
        protected string GetPath(string fileName) => Path.Combine(GetRelativePath(), fileName) + "." + Extension;

        #endregion method
    }
}
