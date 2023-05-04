using Mov.Controllers;
using Mov.Controllers.Repository.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Crud.Persistence.Implement
{
    public class DbObjectRepositoryCommand<TEntity, TBody> : IPersistenceCommand<TEntity> where TEntity : DbObject
    {
        #region フィールド

        private readonly IDbObjectRepository<TEntity, TBody> repository;

        #endregion フィールド

        #region プロパティ

        public ISave<TEntity> Saver { get; }

        public IDelete<TEntity> Deleter { get; }

        #endregion プロパティ

        #region コンストラクター

        public DbObjectRepositoryCommand(IDbObjectRepository<TEntity, TBody> repository)
        {
            this.repository = repository;
            this.Saver = new DbObjectRepositorySaver<TEntity, TBody>(repository);
            this.Deleter = new DbObjectRepositoryDeleter<TEntity, TBody>(repository);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion コンストラクター
    }
}
