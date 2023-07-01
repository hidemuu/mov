using Mov.Core.Models.Entities.DbObjects;
using Mov.Core.Templates.Crud;
using Mov.Core.Templates.Repositories;

namespace Mov.Core.Repositories.Cruds
{
    public class DbObjectRepositoryDeleter<TEntity, TBody> : IDelete<TEntity> where TEntity : DbObject
    {
        #region フィールド

        private readonly IDbObjectRepository<TEntity, TBody> repository;

        #endregion フィールド

        #region コンストラクター

        public DbObjectRepositoryDeleter(IDbObjectRepository<TEntity, TBody> repository)
        {
            this.repository = repository;
        }

        #endregion コンストラクター

        #region メソッド

        public void Delete(TEntity entity)
        {
            repository.Delete(entity);
        }

        #endregion メソッド
    }
}
