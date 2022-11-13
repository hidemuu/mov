using Mov.Accessors.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Persistance.Implement
{
    public class EntityPersistenceCommand<TEntity> : IPersistenceCommand<TEntity>
    {
        #region フィールド

        private readonly IEntityRepository<TEntity> repository;

        #endregion フィールド

        #region コンストラクター

        public EntityPersistenceCommand(IEntityRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public void Write()
        {
            throw new NotImplementedException();
        }

        public void Posts(IEnumerable<TEntity> items)
        {
            throw new NotImplementedException();
        }

        public void Post(TEntity item)
        {
            this.repository.Post(item);
        }

        public void Put(TEntity item)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity item)
        {
            throw new NotImplementedException();
        }

        #endregion メソッド
    }
}
