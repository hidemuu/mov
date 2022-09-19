using Mov.Accessors.Repository.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mov.Accessors.Repository.Implement
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
        public string GetRelativePath() => Path.Combine(this.endpoint, DomainPath);

        /// <summary>
        /// フルパスを取得
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <returns></returns>
        protected string GetPath(string fileName) => Path.Combine(GetRelativePath(), this.fileDir, fileName) + "." + this.extension;

        #endregion メソッド
    }
}
