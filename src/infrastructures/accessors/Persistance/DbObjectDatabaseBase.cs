using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors
{
    public abstract class DbObjectDatabaseBase<T>
    {
        #region フィールド

        private readonly string resourceDir;

        #endregion フィールド

        #region コンストラクター

        public DbObjectDatabaseBase(string resourceDir)
        {
            this.resourceDir = resourceDir;
        }

        #endregion コンストラクター

        #region プロパティ

        public IDictionary<string, T> Repositories { get; protected set; }

        #endregion プロパティ

        #region メソッド

        #endregion メソッド

        #region 内部メソッド

        private IEnumerable<string> GetDirectories()
        {
            return new List<string>();
        }

        #endregion 内部メソッド

    }
}
