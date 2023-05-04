using Mov.Accessors.Persistance.Implement;
using Mov.Controllers;
using Mov.Controllers.Repository.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Crud.Persistence.Implement
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
            this.Reader = new DbObjectRepositoryReader<TEntity, TBody>(repository);
        }

        #endregion コンストラクター
    }
}
