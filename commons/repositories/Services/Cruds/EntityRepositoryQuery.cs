using Mov.Utilities.Templates.Crud;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Repositories.Services.Cruds
{
    public class EntityRepositoryQuery<TEntity> : IPersistenceQuery<TEntity>
    {
        #region フィールド

        private readonly IEntityRepository<TEntity> repository;

        #endregion フィールド

        #region プロパティ

        public IRead<TEntity> Reader { get; }

        #endregion プロパティ

        #region コンストラクター

        public EntityRepositoryQuery(IEntityRepository<TEntity> repository)
        {
            this.repository = repository;
            Reader = new EntityRepositoryReader<TEntity>(repository);
        }

        #endregion コンストラクター
    }
}
