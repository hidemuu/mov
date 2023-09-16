using Mov.Core.Stores.Cruds;
using System;

namespace Mov.Core.Transactions.Services
{
    public class PersistenceTransactionCommand<TEntity> : ITransactionCommand
    {
        #region プロパティ

        public IConnection Connection => throw new NotImplementedException();
        public ITransaction Transaction { get; }

        #endregion プロパティ

        #region コンストラクター

        public PersistenceTransactionCommand(ITransaction transaction)
        {
            Transaction = transaction;
        }

        #endregion コンストラクター

        #region メソッド

        public void Save(ISave<TEntity> saver, TEntity entity)
        {
            saver.Save(entity);
        }

        public void ExecuteNonQuery(string command)
        {
            throw new NotImplementedException();
        }

        #endregion メソッド
    }
}
