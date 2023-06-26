using Mov.Utilities.Templates.Transactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Repositories.Services.Transaction
{
    public class EntityRepositoryConnection<TEntity> : IConnection
    {
        #region フィールド

        private readonly IEntityRepository<TEntity> repository;

        #endregion フィールド


        #region コンストラクター

        public EntityRepositoryConnection(IEntityRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public void Open()
        {

        }

        public void Close()
        {

        }

        public ITransaction BeginTransaction(int isolationLevel = 0, string name = "")
        {
            return new EntityRepositoryTransaction<TEntity>(repository);
        }

        public ITransactionCommand CreateCommand(ITransaction transaction)
        {
            return new EntityRepositoryTransactionCommand<TEntity>(transaction, repository);
        }

        #endregion メソッド

    }
}
