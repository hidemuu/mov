using Mov.Accessors.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Crud.Persistence.Implement
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
            return this.repository.Get();
        }

        public TEntity Read(Guid id)
        {
            throw new NotImplementedException();
            //return this.repository.Get(id);
        }

        #endregion メソッド
    }
}
