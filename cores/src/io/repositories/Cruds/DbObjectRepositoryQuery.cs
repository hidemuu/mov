using Mov.Core.Contexts.DbObjects.Entities;
using Mov.Core.Templates.Crud;
using Mov.Core.Templates.Repositories;

namespace Mov.Core.Repositories.Cruds
{
    public class DbObjectRepositoryQuery<TEntity, TBody> : IPersistenceQuery<TEntity> where TEntity : DbObject
    {
        #region フィールド

        private readonly IDbObjectRepository<TEntity, TBody> repository;

        #endregion フィールド

        #region プロパティ

        public IRead<TEntity> Reader { get; }

        #endregion プロパティ

        #region コンストラクター

        public DbObjectRepositoryQuery(IDbObjectRepository<TEntity, TBody> repository)
        {
            this.repository = repository;
            Reader = new DbObjectRepositoryReader<TEntity, TBody>(repository);
        }

        #endregion コンストラクター
    }
}
