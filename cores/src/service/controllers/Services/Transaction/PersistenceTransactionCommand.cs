using Mov.Core.Templates.Crud;
using Mov.Core.Templates.Transactions;
using System;

namespace Mov.Core.Controllers.Services.Transaction
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
