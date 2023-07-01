using Mov.Core.Templates.Crud;
using Mov.Core.Templates.Repositories;
using System;

namespace Mov.Core.Repositories.Cruds
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
