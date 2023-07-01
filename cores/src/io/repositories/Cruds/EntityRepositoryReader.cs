using Mov.Core.Templates.Crud;
using Mov.Core.Templates.Repositories;
using System;
using System.Collections.Generic;

namespace Mov.Core.Repositories.Cruds
{
    public class EntityRepositoryReader<TEntity> : IRead<TEntity>
    {
        #region フィールド

        private readonly IEntityRepository<TEntity> repository;

        #endregion フィールド

        #region コンストラクター

        public EntityRepositoryReader(IEntityRepository<TEntity> repository)
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
            throw new NotImplementedException();
            //return this.repository.Get(id);
        }

        #endregion メソッド
    }
}
