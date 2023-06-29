using Mov.Core.Templates.Transactions;
using System;

namespace Mov.Core.Repositories.Services.Transaction
{
    public class EntityRepositoryTransactionCommand<TEntity> : ITransactionCommand
    {
        #region フィールド

        private readonly IEntityRepository<TEntity> repository;

        #endregion フィールド

        #region プロパティ

        public IConnection Connection { get; }

        public ITransaction Transaction { get; }

        #endregion プロパティ

        #region コンストラクター

        public EntityRepositoryTransactionCommand(ITransaction transaction, IEntityRepository<TEntity> repository)
        {
            Transaction = transaction;
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public object Execute(string command)
        {
            throw new NotImplementedException();
        }

        public void ExecuteNonQuery(string command)
        {
            throw new NotImplementedException();
        }

        #endregion メソッド
    }
}
