using Mov.Repositories.Models.EntityObjects.DbObjects;
using Mov.Utilities.Templates.Crud;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Repositories.Services.Cruds
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
            repository.Delete(entity);
        }

        #endregion メソッド
    }
}
