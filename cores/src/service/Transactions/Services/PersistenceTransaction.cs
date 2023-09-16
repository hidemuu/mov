using Mov.Core.Stores.Cruds;

namespace Mov.Core.Transactions.Services
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
            RollBack();
        }

        public void RollBack()
        {
            isBegan = false;
        }

        #endregion メソッド
    }
}