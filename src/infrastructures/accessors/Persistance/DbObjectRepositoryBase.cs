using System.IO;

namespace Mov.Accessors
{
    /// <summary>
    /// リポジトリコレクションのベースクラス
    /// </summary>
    public abstract class DbObjectRepositoryBase
    {
        #region フィールド

        /// <summary>
        /// ベースパス
        /// </summary>
        protected readonly string dir;
        /// <summary>
        /// 拡張子
        /// </summary>
        protected readonly string extension;

        #endregion フィールド

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="extension"></param>
        public DbObjectRepositoryBase(string dir, string extension)
        {
            this.dir = dir;
            this.extension = extension;
        }

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