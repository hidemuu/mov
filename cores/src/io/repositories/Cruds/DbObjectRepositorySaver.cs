﻿using Mov.Core.Models.Entities.DbObjects;
using Mov.Core.Templates.Crud;
using Mov.Core.Templates.Repositories;

namespace Mov.Core.Repositories.Cruds
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