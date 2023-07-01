using Mov.Core.Templates.Crud;
using Mov.Core.Templates.Repositories;
using System;

namespace Mov.Core.Repositories.Cruds
{
    public class EntityRepositoryDeleter<TEntity> : IDelete<TEntity>
    {
        #region フィールド

        private readonly IEntityRepository<TEntity> repository;

        #endregion フィールド

        #region コンストラクター

        public EntityRepositoryDeleter(IEntityRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        #endregion メソッド
    }
}
