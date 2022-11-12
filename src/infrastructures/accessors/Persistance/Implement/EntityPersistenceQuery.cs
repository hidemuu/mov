using Mov.Accessors.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mov.Accessors.Persistance.Implement
{
    public class EntityPersistenceQuery<TEntity> : IPersistenceQuery<TEntity>
    {
        #region フィールド

        private readonly IEntityRepository<TEntity> repository;

        #endregion フィールド

        #region コンストラクター

        public EntityPersistenceQuery(IEntityRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public IEnumerable<TEntity> Read()
        {
            return default;
        }

        public IEnumerable<TEntity> Gets()
        {
            return this.repository.Get();
        }

        public IEnumerable<TEntity> Gets(string param)
        {
            return Gets();
        }

        public TEntity Get(Guid id)
        {
            return default;
        }

        public TEntity Get(string param)
        {
            return this.repository.Get(param);
        }

        #endregion メソッド
    }
}
