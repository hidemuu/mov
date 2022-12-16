using Mov.Accessors.Repository;
using Mov.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Crud.Persistence.Implement
{
    public class EntityRepositorySaver<TEntity> : ISave<TEntity>
    {
        #region フィールド

        private readonly IEntityRepository<TEntity> repository;

        #endregion フィールド

        #region コンストラクター

        public EntityRepositorySaver(IEntityRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public void Save(TEntity entity)
        {
            this.repository.Post(entity);
        }

        #endregion メソッド
    }
}
