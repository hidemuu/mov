using Mov.Controllers;
using Mov.Repositories.Models.EntityObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Repositories.Services.Persistences
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
            repository.Post(entity);
        }

        #endregion メソッド
    }
}
