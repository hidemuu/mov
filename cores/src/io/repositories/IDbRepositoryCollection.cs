using System.Collections.Generic;

namespace Mov.Core.Repositories
{
    public interface IDbRepositoryCollection<TRepository, TEntity, TIdentifier>
        where TRepository : IDbRepository<TEntity, TIdentifier>
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