using Mov.Accessors.Repository.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Repository.Implement
{
    public abstract class FileDomainRepositoryBase : IDomainRepository
    {
        #region フィールド

        /// <summary>
        /// 拡張子
        /// </summary>
        protected readonly string extension;

        #endregion フィールド

        #region プロパティ

        public abstract string RelativePath { get; }

        #endregion プロパティ

        #region コンストラクター

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="extension"></param>
        public FileDomainRepositoryBase(string dir, string extension, string encode = SerializeConstants.ENCODE_NAME_UTF8)
        {
            this.extension = extension;
        }

        #endregion コンストラクター

        #region メソッド

        /// <summary>
        /// 相対パスを取得
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns></returns>
        protected string GetRelativePath(string fileName) => fileName + "." + this.extension;

        #endregion メソッド
    }
}
