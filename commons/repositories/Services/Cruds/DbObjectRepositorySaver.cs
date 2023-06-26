using Mov.Repositories.Models.EntityObjects.DbObjects;
using Mov.Utilities.Templates.Crud;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Repositories.Services.Cruds
{
    public class DbObjectRepositorySaver<TEntity, TBody> : ISave<TEntity> where TEntity : DbObject
    {
        #region フィールド

        private readonly IDbObjectRepository<TEntity, TBody> repository;

        #endregion フィールド

        #region コンストラクター

        public DbObjectRepositorySaver(IDbObjectRepository<TEntity, TBody> repository)
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
