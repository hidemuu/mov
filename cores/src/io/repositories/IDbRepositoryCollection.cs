using Mov.Core.Repositories.Schemas.Requests;
using System.Collections.Generic;

namespace Mov.Core.Repositories
{
    public interface IDbRepositoryCollection<TRepository, TEntity, TIdentifier>
        where TRepository : IDbRepository<TEntity, TIdentifier, DbRequestSchemaString>
        where TEntity : IDbSchema<TIdentifier>
    {
        #region method

        IEnumerable<string> GetKeys();

        /// <summary>
        /// 指定のリポジトリを取得
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TRepository GetRepository(string key);

        #endregion method
    }
}