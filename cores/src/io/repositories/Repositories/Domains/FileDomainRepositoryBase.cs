using Mov.Core.Models.Texts;
using Mov.Core.Templates.Repositories;
using System.IO;

namespace Mov.Core.Repositories.Repositories.Domains
{
    public abstract class FileDomainRepositoryBase : IDomainRepository
    {
        #region field

        protected string Endpoint { get; }

        protected FileType FileType { get; }

        protected EncodingValue Encoding { get; }

        #endregion field

        #region property

        public abstract string DomainPath { get; }

        #endregion property

        #region constructor

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="extension"></param>
        public FileDomainRepositoryBase(string endpoint, FileType fileType, EncodingValue encoding)
        {
            this.Endpoint = endpoint;
            this.FileType = fileType;
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
        protected string GetPath(string fileName) => Path.Combine(GetRelativePath(), fileName) + "." + this.FileType.Value;

        #endregion method
    }
}
