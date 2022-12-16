using Mov.Accessors.Repository;
using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Transaction.Implements
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
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public ITransaction BeginTransaction(int isolationLevel = 0, string name = "")
        {
            return new EntityRepositoryTransaction<TEntity>(this.repository);
        }

        public ITransactionCommand CreateCommand()
        {
            return new EntityRepositoryTransactionCommand();
        }

        #endregion メソッド

    }
}
