using Mov.Controllers;
using Mov.Schemas.EntityObjects.DbObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Crud.Persistence.Implement
{
    public class DbObjectRepositoryDeleter<TEntity, TBody> : IDelete<TEntity> where TEntity : DbObject
    {
        #region フィールド

        private readonly IDbObjectRepository<TEntity, TBody> repository;

        #endregion フィールド

        #region コンストラクター

        public DbObjectRepositoryDeleter(IDbObjectRepository<TEntity, TBody> repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public void Delete(TEntity entity)
        {
            this.repository.Delete(entity);
        }

        #endregion メソッド
    }
}
