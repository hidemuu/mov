using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Accessors.Persistance.Implement
{
    public class DbObjectRepositoryReader<TEntity, TBody> : IRead<TEntity> where TEntity : DbObject
    {
        #region フィールド

        private readonly IDbObjectRepository<TEntity, TBody> repository;

        #endregion フィールド

        #region コンストラクター

        public DbObjectRepositoryReader(IDbObjectRepository<TEntity, TBody> repository)
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
            return this.repository.Get(id);
        }

        #endregion メソッド
    }
}
