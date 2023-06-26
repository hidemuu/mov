using Mov.Controllers;
using Mov.Controllers.Repository.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Transaction
{
    public class PersistenceTransaction<TEntity> : ITransaction
    {
        #region フィールド

        private readonly IPersistenceCommand<TEntity> persistence;

        private bool isBegan = false;

        #endregion フィールド

        #region プロパティ

        public bool IsBegan => isBegan;

        #endregion プロパティ

        #region コンストラクター

        public PersistenceTransaction(IPersistenceCommand<TEntity> persistence)
        {
            this.persistence = persistence;
        }

        #endregion コンストラクター


        #region メソッド

        public void Begin()
        {
            isBegan = true;
        }

        public void Commit()
        {
            isBegan = false;
        }

        public void Dispose()
        {
            this.RollBack();
        }

        public void RollBack()
        {
            isBegan = false;
        }

        #endregion メソッド
    }
}
