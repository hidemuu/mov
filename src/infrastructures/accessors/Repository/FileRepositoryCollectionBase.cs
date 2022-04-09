using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mov.Accessors.Repository
{
    public abstract class FileRepositoryCollectionBase
    {
        #region フィールド

        protected readonly string resourceDir;

        protected readonly string extension;

        #endregion

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="resourceDir"></param>
        /// <param name="extension"></param>
        public FileRepositoryCollectionBase(string resourceDir, string extension)
        {
            this.resourceDir = resourceDir;
            this.extension = extension;
        }

        #region メソッド

        protected string GetRepositoryPath(string filePath) => Path.Combine(this.resourceDir, filePath + "." + this.extension);

        #endregion

    }
}
