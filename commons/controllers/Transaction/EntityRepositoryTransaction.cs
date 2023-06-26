using Mov.Controllers;
using Mov.Schemas.EntityObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Transaction.Implements
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
            this.RollBack();
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }

        #endregion メソッド
    }
}
