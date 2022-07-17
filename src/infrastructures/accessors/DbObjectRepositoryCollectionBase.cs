using System.IO;

namespace Mov.Accessors
{
    public abstract class DbObjectRepositoryCollectionBase
    {
        #region フィールド

        protected readonly string dir;

        protected readonly string extension;

        #endregion フィールド

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

        protected string GetRelativePath(string fileName) => fileName + "." + this.extension;

        #endregion メソッド
    }
}