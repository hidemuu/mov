using Mov.Core.Stores;

namespace Mov.Core.Transactions.Services
{
    public class PersistenceTransaction<TEntity, TKey> : ITransaction
    {
        #region フィールド

        private readonly IStoreCommand<TEntity> persistence;

        private bool isBegan = false;

        #endregion フィールド

        #region プロパティ

        public bool IsBegan => isBegan;

        #endregion プロパティ

        #region コンストラクター

        public PersistenceTransaction(IStoreCommand<TEntity> persistence)
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