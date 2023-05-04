using Mov.Accessors.Repository;
using Mov.Controllers;
using Mov.Controllers.Repository.Persistences;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Crud.Persistence.Implement
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
            this.Reader = new EntityRepositoryReader<TEntity>(repository);
        }

        #endregion コンストラクター
    }
}
