using Mov.Core.Models.Texts;
using System.IO;

namespace Mov.Core.Repositories.Implements.Domains
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

        public string RelativePath => Path.Combine(Endpoint, DomainPath);

        #endregion property

        #region constructor

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="extension"></param>
        public FileDomainRepositoryBase(string endpoint, FileType fileType, EncodingValue encoding)
        {
            Endpoint = endpoint;
            FileType = fileType;
            Encoding = encoding;
        }

        #endregion constructor

        #region method

        /// <summary>
        /// フルパスを取得
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns></returns>
        protected string GetPath(string fileName) => Path.Combine(RelativePath, fileName) + "." + FileType.Value;

        #endregion method
    }
}
