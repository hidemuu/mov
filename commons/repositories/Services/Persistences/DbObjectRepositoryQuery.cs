using Mov.Controllers;
using Mov.Repositories.Models.EntityObjects.DbObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Repositories.Services.Persistences
{
    public class DbObjectRepositoryQuery<TEntity, TBody> : IPersistenceQuery<TEntity> where TEntity : DbObject
    {
        #region フィールド

        private readonly IDbObjectRepository<TEntity, TBody> repository;

        #endregion フィールド

        #region プロパティ

        public IRead<TEntity> Reader { get; }

        #endregion プロパティ

        #region コンストラクター

        public DbObjectRepositoryQuery(IDbObjectRepository<TEntity, TBody> repository)
        {
            this.repository = repository;
            Reader = new DbObjectRepositoryReader<TEntity, TBody>(repository);
        }

        #endregion コンストラクター
    }
}
