using Mov.Core.Contexts.DbObjects.Entities;
using Mov.Core.Templates.Crud;
using Mov.Core.Templates.Repositories;
using System;
using System.Collections.Generic;

namespace Mov.Core.Repositories.Cruds
{
    public class DbObjectRepositoryReader<TEntity, TBody> : IRead<TEntity> where TEntity : DbObject
    {
        #region フィールド

        private readonly IDbObjectRepository<TEntity, TBody> repository;

        #endregion フィールド

        #region コンストラクター

        public DbObjectRepositoryReader(IDbObjectRepository<TEntity, TBody> repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public IEnumerable<TEntity> ReadAll()
        {
            return repository.Get();
        }

        public TEntity Read(Guid id)
        {
            return repository.Get(id);
        }

        #endregion メソッド
    }
}
