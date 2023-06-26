using Mov.Utilities.Templates.Transactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Repositories.Services.Transaction
{
    public class EntityRepositoryTransaction<TEntity> : ITransaction
    {
        #region フィールド

        private readonly IEntityRepository<TEntity> repository;

        #endregion フィールド

        #region コンストラクター

        public EntityRepositoryTransaction(IEntityRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター


        #region メソッド

        public void Begin()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            RollBack();
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }

        #endregion メソッド
    }
}
