using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Crud.Persistence.Implement
{
    public class DbObjectRepositorySaver<TEntity, TBody> : ISave<TEntity> where TEntity : DbObject
    {
        #region フィールド

        private readonly IDbObjectRepository<TEntity, TBody> repository;

        #endregion フィールド

        #region コンストラクター

        public DbObjectRepositorySaver(IDbObjectRepository<TEntity, TBody> repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public void Save(TEntity entity)
        {
            this.repository.Post(entity);
        }

        #endregion メソッド
    }
}
