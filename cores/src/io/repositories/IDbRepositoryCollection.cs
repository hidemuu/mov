using System.Collections.Generic;

namespace Mov.Core.Repositories
{
    public interface IDbRepositoryCollection<TRepository, TEntity, TKey>
        where TRepository : IDbRepository<TEntity, TKey>
        where TEntity : IDbSchema<TKey>
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