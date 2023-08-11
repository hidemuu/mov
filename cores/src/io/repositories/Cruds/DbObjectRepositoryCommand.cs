using Mov.Core.Models.DbObjects.Entities;
using Mov.Core.Templates.Crud;
using System;

namespace Mov.Core.Repositories.Cruds
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
            Saver = new DbObjectRepositorySaver<TEntity, TBody>(repository);
            Deleter = new DbObjectRepositoryDeleter<TEntity, TBody>(repository);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion コンストラクター
    }
}
