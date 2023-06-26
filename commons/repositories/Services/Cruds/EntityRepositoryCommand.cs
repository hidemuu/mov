using Mov.Utilities.Templates.Crud;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Repositories.Services.Cruds
{
    public class EntityRepositoryCommand<TEntity> : IPersistenceCommand<TEntity>
    {
        #region フィールド

        private readonly IEntityRepository<TEntity> repository;

        #endregion フィールド

        #region プロパティ

        public ISave<TEntity> Saver { get; }

        public IDelete<TEntity> Deleter { get; }

        #endregion プロパティ

        #region コンストラクター

        public EntityRepositoryCommand(IEntityRepository<TEntity> repository)
        {
            this.repository = repository;
            Saver = new EntityRepositorySaver<TEntity>(repository);
            Deleter = new EntityRepositoryDeleter<TEntity>(repository);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion コンストラクター
    }
}
