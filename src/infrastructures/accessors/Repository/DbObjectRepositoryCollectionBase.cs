using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mov.Accessors.Repository
{
    public abstract class DbObjectRepositoryCollectionBase
    {
        #region フィールド

        protected readonly string dir;

        protected readonly string extension;

        #endregion

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="extension"></param>
        public DbObjectRepositoryCollectionBase(string dir, string extension)
        {
            this.dir = dir;
            this.extension = extension;
        }

        #region メソッド

        protected string GetRepositoryPath(string filePath) => Path.Combine(this.dir, filePath + "." + this.extension);

        #endregion

    }
}
